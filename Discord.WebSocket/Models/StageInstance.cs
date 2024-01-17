using Newtonsoft.Json;

namespace Discord.Models;

public class StageInstance
{
    [JsonProperty("id")]
    public required string Id { get; set; }

    [JsonProperty("guild_id")]
    public required string GuildId { get; set; }

    [JsonProperty("channel_id")]
    public required string ChannelId { get; set; }

    [JsonProperty("topic")]
    public required string Topic { get; set; }

    [JsonProperty("privacy_level")]
    public int PrivacyLevel { get; set; }

    [JsonProperty("discoverable_disabled")]
    public bool DiscoverableDisabled { get; set; }

    [JsonProperty("guild_scheduled_event_id")]
    public string? GuildScheduledEventId { get; set; }
}