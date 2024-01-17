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
    public required UpdatePresenceData Data { get; set; }
}