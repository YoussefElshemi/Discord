using System.Net.WebSockets;
using System.Text;
using Discord.Constants;
using Discord.Enums;
using Discord.Models;
using Discord.Models.Dtos;
using Discord.Models.ReceiveEvents;
using Discord.Models.SendEvents;
using Newtonsoft.Json;

namespace Discord.Extensions;

public static class ClientWebSocketExtensions
{
    public static async Task ConnectAsync(this Client client, string token)
    {
        client.Token = token;
        client.WebSocket = new ClientWebSocket();
        var gatewayUri = new Uri(Endpoints.WebsocketUrl);

        try
        {
            await client.WebSocket.ConnectAsync(gatewayUri, CancellationToken.None);
            Console.WriteLine("WebSocket connection opened.");
            _ = Task.Run(async () => await client.ReceiveAsync(token));
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Unexpected error: {ex.Message}");
        }

        await Task.Delay(-1);
    }

    public static async Task SendAsync(this Client client, string data)
    {
        if (client.WebSocket?.State == WebSocketState.Open)
        {
            var buffer = new ArraySegment<byte>(Encoding.UTF8.GetBytes(data));
            await client.WebSocket.SendAsync(buffer, WebSocketMessageType.Text, true, CancellationToken.None);
            Console.WriteLine($"Sent message: {data}");
        }
    }

    private static async Task ReceiveAsync(this Client client, string token)
    {
        try
        {
            while (client.WebSocket is { State: WebSocketState.Open })
            {
                var buffer = new ArraySegment<byte>(new byte[4096]);
                var result = await client.WebSocket.ReceiveAsync(buffer, CancellationToken.None);

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
                            client.LastSequence = websocketMessage.SequenceNumber;
                        }

                        client.HandleDispatchEvent(websocketMessage);
                        break;
                    }

                    case OpCode.Heartbeat:
                    {
                        await client.SendHeartbeatAsync();
                        break;
                    }

                    case OpCode.Reconnect:
                        JsonConvert.DeserializeObject<ReconnectEvent>(message);
                        break;

                    case OpCode.InvalidSession:
                        var invalidSession = JsonConvert.DeserializeObject<InvalidSessionEvent>(message);
                        if (invalidSession?.Data != null)
                        {
                            if (invalidSession.Data.Value && !string.IsNullOrWhiteSpace(client.SessionId))
                            {
                                client.ResumeAsync(client.SessionId);
                            }
                        }

                        break;

                    case OpCode.Hello:
                    {
                        var helloEvent = JsonConvert.DeserializeObject<HelloEvent>(message);
                        if (helloEvent?.Data != null)
                        {
                            client.HeartbeatInterval = helloEvent.Data.HeartbeatInterval;
                        }

                        client.StartHeartbeatAsync();
                        break;
                    }

                    case OpCode.HeartbeatAck when client.FirstAck:
                    {
                        client.FirstAck = false;
                        var payload = new IdentifyEvent
                        {
                            Data = new IdentifyData
                            {
                                Token = token
                            }
                        };

                        await client.SendAsync(payload.ToJson());
                        break;
                    }
                }
            }

            if (client.WebSocket?.State != WebSocketState.Open)
            {
                client.HandleCloseStatus(client.WebSocket?.CloseStatus);
                await client.ConnectAsync(token);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"WebSocket receive error: {ex}");
            throw;
        }
    }
}