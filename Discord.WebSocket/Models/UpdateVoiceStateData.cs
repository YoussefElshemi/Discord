﻿using Newtonsoft.Json;

namespace Discord.Models;

public class UpdateVoiceStateData
{
    [JsonProperty("guild_id")]
    public required string GuildId { get; set; }

    [JsonProperty("channel_id")]
    public string? ChannelId { get; set; }

    [JsonProperty("self_mute")]
    public bool SelfMute { get; set; }

    [JsonProperty("self_deaf")]
    public bool SelfDeaf { get; set; }
}