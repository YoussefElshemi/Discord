using Newtonsoft.Json;

namespace Discord.Models.Dtos;

public class HelloEventDto : BaseEventDto
{
    [JsonProperty("d")]
    public HelloData? Data { get; set; }

    public class HelloData
    {
        [JsonProperty("heartbeat_interval")]
        public int HeartbeatInterval { get; set; }
    }
}