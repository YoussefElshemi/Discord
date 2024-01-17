﻿using System.Net.WebSockets;
using System.Text;
using Discord.Constants;
using Discord.Enums;
using Discord.Exceptions;
using Discord.Extensions;
using Discord.Helpers;
using Discord.Models.DispatchEvents;
using Discord.Models.Dtos;
using Discord.Models.ReceiveEvents;
using Discord.Models.SendEvents;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Discord.Models;

public class Client
{
    public readonly Dictionary<string, GuildChannel> Channels = new();
    public readonly Dictionary<string, Guild> Guilds = new();
    public readonly Dictionary<string, User> Users = new();

    public string? Token;
    public User? User;

    private ClientWebSocket? _webSocket;
    private CancellationTokenSource? _heartbeatCancellationTokenSource;
    private int _heartbeatInterval;
    private bool _firstAck = true;
    private int? _lastSequence;
    private string? _sessionId;

    public async Task ConnectAsync(string token)
    {
        Token = token;
        _webSocket = new ClientWebSocket();
        var gatewayUri = new Uri(Endpoints.WebsocketUrl);

        try
        {
            await _webSocket.ConnectAsync(gatewayUri, CancellationToken.None);
            Console.WriteLine("WebSocket connection opened.");
            _ = Task.Run(async () => await ReceiveAndHandleMessagesAsync(token));
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Unexpected error: {ex.Message}");
        }

        await Task.Delay(-1);
    }

    public async void RequestGuildMembers(GuildMembersRequest guildMembersRequest)
    {
        var payload = new RequestGuildMembersEvent
        {
            Data = new RequestGuildMembersData
            {
                GuildId = guildMembersRequest.GuildId,
                Query = guildMembersRequest.Query,
                Limit = guildMembersRequest.Limit,
                Presences = guildMembersRequest.Presences,
                UserIds = guildMembersRequest.UserIds,
                Nonce = guildMembersRequest.Nonce
            }
        };

        await SendAsync(payload.ToJson());
    }

    public async void UpdateVoiceState(UpdateVoiceStateRequest updateVoiceStateRequest)
    {
        var payload = new UpdateVoiceStateEvent
        {
            Data = new UpdateVoiceStateData
            {
                ChannelId = updateVoiceStateRequest.ChannelId,
                GuildId = updateVoiceStateRequest.GuildId,
                SelfDeaf = updateVoiceStateRequest.SelfDeaf,
                SelfMute = updateVoiceStateRequest.SelfMute
            }
        };

        await SendAsync(payload.ToJson());
    }

    private async void Resume(string sessionId)
    {
        if (string.IsNullOrWhiteSpace(Token) || !_lastSequence.HasValue) return;

        var payload = new ResumeEvent
        {
            Data = new ResumeData
            {
                Token = Token,
                SessionId = sessionId,
                Seq = _lastSequence.Value
            }
        };

        await SendAsync(payload.ToJson());
    }

    private async Task SendAsync(string data)
    {
        if (_webSocket?.State == WebSocketState.Open)
        {
            var buffer = new ArraySegment<byte>(Encoding.UTF8.GetBytes(data));
            await _webSocket.SendAsync(buffer, WebSocketMessageType.Text, true, CancellationToken.None);
            Console.WriteLine($"Sent message: {data}");
        }
    }

    private async Task ReceiveAndHandleMessagesAsync(string token)
    {
        try
        {
            while (_webSocket is { State: WebSocketState.Open })
            {
                var buffer = new ArraySegment<byte>(new byte[4096]);
                var result = await _webSocket.ReceiveAsync(buffer, CancellationToken.None);

                if (result.MessageType != WebSocketMessageType.Text) continue;
                if (buffer.Array == null) continue;

                var message = Encoding.UTF8.GetString(buffer.Array, 0, result.Count);
                Console.WriteLine($"Received message: {message}");

                var websocketMessage = JsonConvert.DeserializeObject<WebsocketMessageDto>(message);
                if (websocketMessage is null)
                {
                    throw new Exception("InvalidWebhookMessage");
                }

                switch (websocketMessage.OpCode)
                {
                    case OpCode.Dispatch:
                    {
                        if (websocketMessage.SequenceNumber.HasValue)
                        {
                            _lastSequence = websocketMessage.SequenceNumber;
                        }

                        HandleDispatchEvent(websocketMessage);
                        break;
                    }

                    case OpCode.Heartbeat:
                    {
                        await SendHeartbeatAsync();
                        break;
                    }

                    case OpCode.Reconnect:
                        JsonConvert.DeserializeObject<ReconnectEvent>(message);
                        break;

                    case OpCode.InvalidSession:
                        var invalidSession = JsonConvert.DeserializeObject<InvalidSessionEvent>(message);
                        if (invalidSession?.Data != null)
                        {
                            if (invalidSession.Data.Value && !string.IsNullOrWhiteSpace(_sessionId))
                            {
                                Resume(_sessionId);
                            }
                        }

                        break;

                    case OpCode.Hello:
                    {
                        var helloEvent = JsonConvert.DeserializeObject<HelloEvent>(message);
                        if (helloEvent?.Data != null)
                        {
                            _heartbeatInterval = helloEvent.Data.HeartbeatInterval;
                        }

                        StartHeartbeat();
                        break;
                    }

                    case OpCode.HeartbeatAck when _firstAck:
                    {
                        _firstAck = false;
                        var payload = new IdentifyEvent
                        {
                            Data =
                            {
                                Token = token
                            }
                        };

                        await SendAsync(payload.ToJson());
                        break;
                    }
                }
            }

            if (_webSocket?.State != WebSocketState.Open)
            {
                HandleCloseStatus(_webSocket?.CloseStatus);
                await ConnectAsync(token);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"WebSocket receive error: {ex}");
            throw;
        }
    }

    private async void StartHeartbeat()
    {
        _heartbeatCancellationTokenSource = new CancellationTokenSource();

        while (!_heartbeatCancellationTokenSource.Token.IsCancellationRequested)
        {
            await SendHeartbeatAsync();

            var rand = new Random();
            var jitter = rand.NextDouble();
            var interval = (int)Math.Round(_heartbeatInterval * jitter);

            await Task.Delay(interval);
        }
    }

    private async Task SendHeartbeatAsync()
    {
        var heartbeatPayload = new HeartbeatEvent();

        if (_lastSequence.HasValue)
        {
            heartbeatPayload.Data = _lastSequence.Value;
        }

        await SendAsync(heartbeatPayload.ToJson());
    }

    public void Disconnect()
    {
        _heartbeatCancellationTokenSource?.Cancel();
        _webSocket?.Abort();
    }

    private async void Reconnect()
    {
        _webSocket = new ClientWebSocket();
        var gatewayUri = new Uri(Endpoints.WebsocketUrl);

        await _webSocket.ConnectAsync(gatewayUri, CancellationToken.None);
    }

    private void HandleCloseStatus(WebSocketCloseStatus? closeStatus)
    {
        var errorCode = ErrorCodeHelper.GetErrorCodeDetails((int)closeStatus!);
        if (errorCode is null)
        {
            throw new WebSocketClosureException(closeStatus);
        }

        if (errorCode.Reconnect)
        {
            Console.WriteLine($"{closeStatus} - {errorCode.Description}: {errorCode.Explanation}");
            Reconnect();
        }
        else
        {
            throw new WebSocketClosureException(closeStatus, errorCode.Description, errorCode.Explanation);
        }
    }

    private void HandleDispatchEvent(WebsocketMessageDto websocketMessage)
    {
        if (websocketMessage.Data == null) return;
        var jObj = websocketMessage.Data as JObject ?? JObject.FromObject(websocketMessage.Data);

        switch (websocketMessage.EventName)
        {
            case Event.Ready:
            {
                var eventObject = jObj.ToObject<ReadyEvent>();
                User = eventObject?.User;
                _sessionId = eventObject?.SessionId;
                break;
            }

            case Event.ApplicationCommandPermissionsUpdate:
            {
                var eventObject = jObj.ToObject<ApplicationCommandPermissionsUpdateEvent>();
                break;
            }

            case Event.GuildCreate:
            {
                var eventObject = jObj.ToObject<GuildCreateEvent>();
                if (eventObject == null) return;

                Guilds[eventObject.Id] = eventObject;

                if (eventObject.Members != null)
                {
                    Array.ForEach(eventObject.Members, member => Users[member.User.Id] = member.User);
                }

                if (eventObject.Channels != null)
                {
                    Array.ForEach(eventObject.Channels, channel => Channels[channel.Id] = channel);
                }

                break;
            }
        }
    }
}

public class UpdateVoiceStateRequest : UpdateVoiceStateData
{
}

public class GuildMembersRequest : RequestGuildMembersData
{
}