using Discord.Enums;
using Discord.Models.Dtos;
using Newtonsoft.Json;

namespace Discord.Models.SendEvents;

public class UpdateVoiceStateEvent : BaseEventDto
{

    public UpdateVoiceStateEvent()
    {
        OpCode = OpCode.VoiceStateUpdate;
    }

    [JsonProperty("d")]
    public required UpdateVoiceStateData Data { get; set; }
}