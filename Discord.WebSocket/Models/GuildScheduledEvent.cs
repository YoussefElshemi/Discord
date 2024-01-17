using Discord.Enums;
using Newtonsoft.Json;

namespace Discord.Models;

public class GuildScheduledEvent
{
    [JsonProperty("id")]
    public string Id { get; set; } = null!;

    [JsonProperty("guild_id")]
    public string GuildId { get; set; } = null!;

    [JsonProperty("channel_id")]
    public string? ChannelId { get; set; }

    [JsonProperty("creator_id")]
    public string? CreatorId { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; } = null!;

    [JsonProperty("description")]
    public string? Description { get; set; }

    [JsonProperty("scheduled_start_time")]
    public DateTime ScheduledStartTime { get; set; }

    [JsonProperty("scheduled_end_time")]
    public DateTime? ScheduledEndTime { get; set; }

    [JsonProperty("privacy_level")]
    public GuildScheduledEventPrivacyLevel GuildScheduledEventPrivacyLevel { get; set; }

    [JsonProperty("status")]
    public GuildScheduledEventStatus Status { get; set; }

    [JsonProperty("entity_type")]
    public GuildScheduledEventEntityType EntityType { get; set; }

    [JsonProperty("entity_id")]
    public string? EntityId { get; set; }

    [JsonProperty("entity_metadata")]
    public GuildScheduledEventEntityMetadata? EntityMetadata { get; set; }

    [JsonProperty("creator")]
    public User Creator { get; set; } = null!;

    [JsonProperty("user_count")]
    public int? UserCount { get; set; }

    [JsonProperty("image")]
    public string? Image { get; set; }
}