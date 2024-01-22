using System.Net.WebSockets;
using Discord.Constants;
using Discord.Exceptions;
using Discord.Extensions;
using Discord.Helpers;
using Discord.Models.DispatchEvents;
using Discord.Models.Dtos;
using Discord.Models.SendEvents;
using Newtonsoft.Json.Linq;

namespace Discord.Models;

public class Client : EventEmitter
{
    public Dictionary<string, Channel> Channels { get; } = new();
    public Dictionary<string, Guild> Guilds { get; } = new();
    public Dictionary<string, User> Users { get; } = new();

    public string? Token;
    public User? User;

    internal ClientWebSocket? WebSocket;
    private CancellationTokenSource? _heartbeatCancellationTokenSource;
    internal int HeartbeatInterval;
    internal bool FirstAck = true;
    internal int? LastSequence;
    internal string? SessionId;

    public async void RequestGuildMembersAsync(GuildMembersRequest guildMembersRequest)
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

        await this.SendAsync(payload.ToJson());
    }

    public async void UpdateVoiceStateAsync(UpdateVoiceStateRequest updateVoiceStateRequest)
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

        await this.SendAsync(payload.ToJson());
    }

    public async void ResumeAsync(string sessionId)
    {
        if (string.IsNullOrWhiteSpace(Token) || !LastSequence.HasValue) return;

        var payload = new ResumeEvent
        {
            Data = new ResumeData
            {
                Token = Token,
                SessionId = sessionId,
                Seq = LastSequence.Value
            }
        };

        await this.SendAsync(payload.ToJson());
    }

    public async void StartHeartbeatAsync()
    {
        _heartbeatCancellationTokenSource = new CancellationTokenSource();

        while (!_heartbeatCancellationTokenSource.Token.IsCancellationRequested)
        {
            await SendHeartbeatAsync();

            var rand = new Random();
            var jitter = rand.NextDouble();
            var interval = (int)Math.Round(HeartbeatInterval * jitter);

            await Task.Delay(interval);
        }
    }

    internal async Task SendHeartbeatAsync()
    {
        var heartbeatPayload = new HeartbeatEvent();

        if (LastSequence.HasValue)
        {
            heartbeatPayload.Data = LastSequence.Value;
        }

        await this.SendAsync(heartbeatPayload.ToJson());
    }

    public void Disconnect()
    {
        _heartbeatCancellationTokenSource?.Cancel();
        WebSocket?.Abort();
    }

    private async void ReconnectAsync()
    {
        WebSocket = new ClientWebSocket();
        var gatewayUri = new Uri(Endpoints.WebsocketUrl);

        await WebSocket.ConnectAsync(gatewayUri, CancellationToken.None);
    }

    internal void HandleCloseStatus(WebSocketCloseStatus? closeStatus)
    {
        var errorCode = ErrorCodeHelper.GetErrorCodeDetails(closeStatus);

        if (errorCode is null)
        {
            throw new WebSocketClosureException(closeStatus);
        }

        if (errorCode.Reconnect)
        {
            Console.WriteLine($"{closeStatus} - {errorCode.Description}: {errorCode.Explanation}");
            ReconnectAsync();
        }
        else
        {
            throw new WebSocketClosureException(closeStatus, errorCode.Description, errorCode.Explanation);
        }
    }

    internal void HandleDispatchEvent(WebsocketMessageDto websocketMessage)
    {
        if (websocketMessage.Data == null) return;
        var jObj = websocketMessage.Data as JObject ?? JObject.FromObject(websocketMessage.Data);

        switch (websocketMessage.EventName)
        {
            case Event.Ready:
            {
                var eventObject = jObj.ToObject<ReadyEvent>();
                if (eventObject == null) return;

                User = eventObject.User;
                SessionId = eventObject.SessionId;

                EmitReadyEvent(
                    new ClientEventArgs<ReadyEvent>
                    {
                        Event = eventObject,
                        Client = this
                    }
                );

                break;
            }

            case Event.ApplicationCommandPermissionsUpdate:
            {
                var eventObject = jObj.ToObject<GuildApplicationCommandPermissionsUpdateEvent>();
                if (eventObject == null) return;

                EmitApplicationCommandPermissionsUpdateEvent(
                    new ClientEventArgs<GuildApplicationCommandPermissionsUpdateEvent>
                    {
                        Event = eventObject,
                        Client = this
                    }
                );

                break;
            }

            case Event.AutoModerationRuleCreate:
            {
                var eventObject = jObj.ToObject<AutoModerationRuleEvent>();
                if (eventObject == null) return;

                EmitAutoModerationRuleCreateEvent(
                    new ClientEventArgs<AutoModerationRuleEvent>
                    {
                        Event = eventObject,
                        Client = this
                    }
                );

                break;
            }

            case Event.AutoModerationRuleUpdate:
            {
                var eventObject = jObj.ToObject<AutoModerationRuleEvent>();
                if (eventObject == null) return;

                EmitAutoModerationRuleUpdateEvent(
                    new ClientEventArgs<AutoModerationRuleEvent>
                    {
                        Event = eventObject,
                        Client = this
                    }
                );

                break;
            }

            case Event.AutoModerationRuleDelete:
            {
                var eventObject = jObj.ToObject<AutoModerationRuleEvent>();
                if (eventObject == null) return;

                EmitAutoModerationRuleDeleteEvent(
                    new ClientEventArgs<AutoModerationRuleEvent>
                    {
                        Event = eventObject,
                        Client = this
                    }
                );

                break;
            }

            case Event.AutoModerationActionExecution:
            {
                var eventObject = jObj.ToObject<AutoModerationActionExecutionEvent>();
                if (eventObject == null) return;

                EmitAutoModerationActionExecutionEvent(
                    new ClientEventArgs<AutoModerationActionExecutionEvent>
                    {
                        Event = eventObject,
                        Client = this
                    }
                );

                break;
            }

            case Event.ChannelCreate:
            {
                var eventObject = jObj.ToObject<ChannelEvent>();
                if (eventObject == null) return;

                if (!string.IsNullOrWhiteSpace(eventObject.GuildId))
                {
                    Guilds[eventObject.GuildId].Channels[eventObject.Id] = eventObject;
                }

                Channels[eventObject.Id] = eventObject;

                EmitChannelCreateEvent(
                    new ClientEventArgs<ChannelEvent>
                    {
                        Event = eventObject,
                        Client = this
                    }
                );

                break;
            }

            case Event.ChannelUpdate:
            {
                var eventObject = jObj.ToObject<ChannelEvent>();
                if (eventObject == null) return;

                if (!string.IsNullOrWhiteSpace(eventObject.GuildId))
                {
                    Guilds[eventObject.GuildId].Channels[eventObject.Id] = eventObject;
                }

                Channels[eventObject.Id] = eventObject;

                EmitChannelUpdateEvent(
                    new ClientEventArgs<ChannelEvent>
                    {
                        Event = eventObject,
                        Client = this
                    }
                );

                break;
            }

            case Event.ChannelDelete:
            {
                var eventObject = jObj.ToObject<ChannelEvent>();
                if (eventObject == null) return;

                if (!string.IsNullOrWhiteSpace(eventObject.GuildId))
                {
                    Guilds[eventObject.GuildId].Channels.Remove(eventObject.Id);
                }

                Channels.Remove(eventObject.Id);

                EmitChannelDeleteEvent(
                    new ClientEventArgs<ChannelEvent>
                    {
                        Event = eventObject,
                        Client = this
                    }
                );

                break;
            }

            case Event.ChannelPinsUpdate:
            {
                var eventObject = jObj.ToObject<ChannelPinsUpdateEvent>();
                if (eventObject == null) return;

                EmitChannelPinsUpdateEvent(
                    new ClientEventArgs<ChannelPinsUpdateEvent>
                    {
                        Event = eventObject,
                        Client = this
                    }
                );

                break;
            }

            case Event.ThreadCreate:
            {
                var eventObject = jObj.ToObject<ThreadEvent>();
                if (eventObject == null) return;

                if (!string.IsNullOrWhiteSpace(eventObject.GuildId))
                {
                    Guilds[eventObject.GuildId].Channels[eventObject.Id] = eventObject;
                }

                Channels[eventObject.Id] = eventObject;

                EmitThreadCreateEvent(
                    new ClientEventArgs<ThreadEvent>
                    {
                        Event = eventObject,
                        Client = this
                    }
                );

                break;
            }

            case Event.ThreadUpdate:
            {
                var eventObject = jObj.ToObject<ThreadEvent>();
                if (eventObject == null) return;

                if (!string.IsNullOrWhiteSpace(eventObject.GuildId))
                {
                    Guilds[eventObject.GuildId].Channels[eventObject.Id] = eventObject;
                }

                Channels[eventObject.Id] = eventObject;

                EmitThreadUpdateEvent(
                    new ClientEventArgs<ThreadEvent>
                    {
                        Event = eventObject,
                        Client = this
                    }
                );

                break;
            }

            case Event.ThreadDelete:
            {
                var eventObject = jObj.ToObject<ThreadEvent>();
                if (eventObject == null) return;

                if (!string.IsNullOrWhiteSpace(eventObject.GuildId))
                {
                    Guilds[eventObject.GuildId].Channels[eventObject.Id] = eventObject;
                }

                Channels.Remove(eventObject.Id);

                EmitThreadDeleteEvent(
                    new ClientEventArgs<ThreadEvent>
                    {
                        Event = eventObject,
                        Client = this
                    }
                );

                break;
            }

            case Event.ThreadListSync:
            {
                var eventObject = jObj.ToObject<ThreadListSyncEvent>();
                if (eventObject == null) return;

                Array.ForEach(eventObject.Threads, thread => { Guilds[eventObject.GuildId].Channels[thread.Id] = thread; });

                // TODO: add logic to handle thread synchronization
                EmitThreadListSyncEvent(
                    new ClientEventArgs<ThreadListSyncEvent>
                    {
                        Event = eventObject,
                        Client = this
                    }
                );

                break;
            }

            case Event.ThreadMemberUpdate:
            {
                var eventObject = jObj.ToObject<ThreadMemberUpdateEvent>();
                if (eventObject == null) return;

                // TODO: add logic to handle thread member update
                EmitThreadMemberUpdateEvent(
                    new ClientEventArgs<ThreadMemberUpdateEvent>
                    {
                        Event = eventObject,
                        Client = this
                    }
                );

                break;
            }

            case Event.ThreadMembersUpdate:
            {
                var eventObject = jObj.ToObject<ThreadMembersUpdateEvent>();
                if (eventObject == null) return;

                // TODO: add logic to handle thread members update
                EmitThreadMembersUpdateEvent(
                    new ClientEventArgs<ThreadMembersUpdateEvent>
                    {
                        Event = eventObject,
                        Client = this
                    }
                );

                break;
            }

            case Event.EntitlementCreate:
            {
                var eventObject = jObj.ToObject<EntitlementEvent>();
                if (eventObject == null) return;

                // TODO
                EmitEntitlementCreateEvent(
                    new ClientEventArgs<EntitlementEvent>
                    {
                        Event = eventObject,
                        Client = this
                    }
                );

                break;
            }

            case Event.EntitlementUpdate:
            {
                var eventObject = jObj.ToObject<EntitlementEvent>();
                if (eventObject == null) return;

                // TODO
                EmitEntitlementUpdateEvent(
                    new ClientEventArgs<EntitlementEvent>
                    {
                        Event = eventObject,
                        Client = this
                    }
                );

                break;
            }

            case Event.EntitlementDelete:
            {
                var eventObject = jObj.ToObject<EntitlementEvent>();
                if (eventObject == null) return;

                // TODO
                EmitEntitlementDeleteEvent(
                    new ClientEventArgs<EntitlementEvent>
                    {
                        Event = eventObject,
                        Client = this
                    }
                );

                break;
            }

            case Event.GuildCreate:
            {
                var eventObject = jObj.ToObject<GuildCreateEvent>();
                if (eventObject == null) return;

                Guilds[eventObject.Id] = eventObject;

                if (eventObject._members != null)
                {
                    Array.ForEach(eventObject._members, member =>
                    {
                        Users[member.User.Id] = member.User;
                        Guilds[eventObject.Id].Members[member.User.Id] = member;
                    });
                }

                if (eventObject._channels != null)
                {
                    Array.ForEach(eventObject._channels, channel =>
                    {
                        Channels[channel.Id] = channel;
                        Guilds[eventObject.Id].Channels[channel.Id] = channel;
                    });
                }

                Array.ForEach(eventObject._roles, role => { Guilds[eventObject.Id].Roles[role.Id] = role; });

                EmitGuildCreateEvent(
                    new ClientEventArgs<GuildCreateEvent>
                    {
                        Event = eventObject,
                        Client = this
                    }
                );

                break;
            }

            case Event.GuildUpdate:
            {
                var eventObject = jObj.ToObject<GuildEvent>();
                if (eventObject == null) return;

                Guilds[eventObject.Id] = eventObject;

                EmitGuildUpdateEvent(
                    new ClientEventArgs<GuildEvent>
                    {
                        Event = eventObject,
                        Client = this
                    }
                );

                break;
            }

            case Event.GuildDelete:
            {
                var eventObject = jObj.ToObject<GuildEvent>();
                if (eventObject == null) return;

                var channels = Channels.Where(channel => channel.Value.GuildId == eventObject.Id);
                foreach (var channel in channels)
                {
                    Channels.Remove(channel.Value.Id);
                }

                Guilds.Remove(eventObject.Id);

                EmitGuildDeleteEvent(
                    new ClientEventArgs<GuildEvent>
                    {
                        Event = eventObject,
                        Client = this
                    }
                );

                break;
            }
        }
    }
}