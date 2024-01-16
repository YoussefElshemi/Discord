using Newtonsoft.Json;

namespace Discord.Models;

public class StageInstance
{
    [JsonProperty("id")]
    public string Id { get; set; } = null!;

    [JsonProperty("guild_id")]
    public string GuildId { get; set; } = null!;

    [JsonProperty("channel_id")]
    public string ChannelId { get; set; } = null!;

    [JsonProperty("topic")]
    public string Topic { get; set; } = null!;

    [JsonProperty("privacy_level")]
    public int PrivacyLevel { get; set; }

    [JsonProperty("discoverable_disabled")]
    public bool DiscoverableDisabled { get; set; }

    [JsonProperty("guild_scheduled_event_id")]
    public string? GuildScheduledEventId { get; set; }
}