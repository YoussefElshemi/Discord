using Discord.Enums;
using Discord.Models.Dtos;
using Newtonsoft.Json;

namespace Discord.Models.SendEvents;

public class UpdatePresenceEvent : BaseEventDto
{
    public UpdatePresenceEvent()
    {
        OpCode = OpCode.PresenceUpdate;
    }

    [JsonProperty("d")]
    public UpdatePresenceData Data { get; set; } = new();
}