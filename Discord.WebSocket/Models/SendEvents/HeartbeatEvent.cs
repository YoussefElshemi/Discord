using Discord.Enums;
using Discord.Models.Dtos;
using Newtonsoft.Json;

namespace Discord.Models.SendEvents;

public class HeartbeatEvent : BaseEventDto
{
    [JsonProperty("d")]
    public int? Data { get; set; }
    
    public HeartbeatEvent()
    {
        OpCode = OpCode.Heartbeat;
    }
}