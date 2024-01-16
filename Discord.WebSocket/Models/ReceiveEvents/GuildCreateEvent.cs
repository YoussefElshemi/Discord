﻿using Newtonsoft.Json;

namespace Discord.Models.ReceiveEvents;

public class GuildCreateEvent : Guild
{ 
    [JsonProperty("joined_at")]
    public DateTime? JoinedAt { get; set; }

    [JsonProperty("large")]
    public bool? Large { get; set; }

    [JsonProperty("member_count")]
    public int? MemberCount { get; set; }

    [JsonProperty("voice_states")]
    public VoiceState[]? VoiceStates { get; set; }

    [JsonProperty("members")]
    public GuildMember[]? Members { get; set; }
    
    [JsonProperty("channels")]
    public GuildChannel[]? Channels { get; set; }
    
    [JsonProperty("threads")]
    public GuildChannel[]? Threads { get; set; }
    
    [JsonProperty("presences")]
    public PresenceUpdate[]? Presences { get; set; }
    
    [JsonProperty("stage_instances")]
    public StageInstance[]? StageInstances { get; set; }
    
    [JsonProperty("guild_scheduled_events")]
    public GuildScheduledEvent[]? GuildScheduledEvents { get; set; }
}