using System.Net.WebSockets;
using System.Text;
using Discord.Constants;
using Discord.Enums;
using Discord.Exceptions;
using Discord.Extensions;
using Discord.Helpers;
using Discord.Models.Dtos;
using Discord.Models.ReceiveEvents;
using Discord.Models.SendEvents;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Discord.Models;

public class Client
{    
    private int _heartbeatInterval;
    private int? _lastSequence;
    private bool _firstAck = true;
    
    private ClientWebSocket? _webSocket;
    private CancellationTokenSource? _heartbeatCancellationTokenSource;

    public User? User;
    public string? Token;

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
                    
                var messageData = JsonConvert.DeserializeObject<WebsocketMessageDto>(message);
                if (messageData is null)
                {
                    throw new Exception("InvalidWebhookMessage");
                }

                switch (messageData.OpCode)
                {
                    case OpCode.Dispatch:
                    {
                        if (messageData.SequenceNumber.HasValue)
                        {
                            _lastSequence = messageData.SequenceNumber;
                        }
                        
                        HandleDispatchEvent(messageData);
                        break;
                    }
                    
                    case OpCode.Heartbeat:
                    {
                        await SendHeartbeatAsync(); 
                        break;
                    }
                    
                    case OpCode.Hello:
                    {
                        var heartbeatData = JsonConvert.DeserializeObject<HelloEventDto>(message);
                        if (heartbeatData?.Data != null)
                        {
                            _heartbeatInterval = heartbeatData.Data.HeartbeatInterval;
                        }

                        StartHeartbeat();
                        break;
                    }
                    
                    case OpCode.HeartbeatAck when _firstAck:
                    {
                        _firstAck = false;
                        var identifyPayload = new IdentifyEvent
                        {
                            Data =
                            {
                                Token = token
                            }
                        };

                        await SendAsync(identifyPayload.ToJson());
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

    private static void HandleCloseStatus(WebSocketCloseStatus? closeStatus)
    {
        var errorCode = ErrorCodeHelper.GetErrorCodeDetails((int)closeStatus!);
        if (errorCode is null) 
        {
            throw new WebSocketClosureException(closeStatus);
        }
        
        if (errorCode.Reconnect)
        {
            Console.WriteLine($"{closeStatus} - {errorCode.Description}: {errorCode.Explanation}");
            // TODO: reconnect to websocket
        }
        else
        {
            throw new WebSocketClosureException(closeStatus, errorCode.Description, errorCode.Explanation);
        }
    }

    private void HandleDispatchEvent(WebsocketMessageDto messageData)
    {
        if (messageData.Data == null) return;
        var jObj = messageData.Data as JObject ?? JObject.FromObject(messageData.Data);

        switch (messageData.EventName)
        { 
            case Event.Ready:
            {
                var readyEventData = jObj.ToObject<ReadyEvent>();
                User = readyEventData?.User;
                break;
            }
            
            case Event.GuildCreate:
                var guildCreateEventData = jObj.ToObject<GuildCreateEvent>();
                break;
        }
    }
}

public class UpdateVoiceStateRequest : UpdateVoiceStateData
{
}

public class GuildMembersRequest : RequestGuildMembersData
{
    
}