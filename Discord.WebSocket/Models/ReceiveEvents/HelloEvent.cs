using Discord.Models.Dtos;
using Newtonsoft.Json;

namespace Discord.Models.ReceiveEvents;

public class HelloEvent : BaseEventDto
{
    [JsonProperty("d")]
    public HelloData? Data { get; set; }

    public class HelloData
    {
        [JsonProperty("heartbeat_interval")]
        public int HeartbeatInterval { get; set; }
    }
}