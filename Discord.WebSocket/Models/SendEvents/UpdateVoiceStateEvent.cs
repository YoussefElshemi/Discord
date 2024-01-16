using Discord.Enums;
using Discord.Models.Dtos;
using Newtonsoft.Json;

namespace Discord.Models.SendEvents;

public class UpdateVoiceStateEvent : BaseEventDto
{
    [JsonProperty("d")] 
    public UpdateVoiceStateData Data { get; set; } = new();
    
    public UpdateVoiceStateEvent()
    {
        OpCode = OpCode.VoiceStateUpdate;
    }
}

public class UpdateVoiceStateData
{
    [JsonProperty("guild_id")]
    public string GuildId { get; set; } = null!;

    [JsonProperty("channel_id")]
    public string? ChannelId { get; set; }

    [JsonProperty("self_mute")]
    public bool SelfMute { get; set; }

    [JsonProperty("self_deaf")]
    public bool SelfDeaf { get; set; }
}