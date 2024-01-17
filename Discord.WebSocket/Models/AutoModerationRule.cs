using Discord.Enums;
using Newtonsoft.Json;

namespace Discord.Models;

public class AutoModerationRule
{
    [JsonProperty("id")]
    public required string Id { get; set; }

    [JsonProperty("guild_id")]
    public required string GuildId { get; set; }

    [JsonProperty("name")]
    public required string Name { get; set; }

    [JsonProperty("creator_id")]
    public required string CreatorId { get; set; }

    [JsonProperty("event_type")]
    public AutoModerationEventType EventType { get; set; }

    [JsonProperty("trigger_type")]
    public AutoModerationTriggerType TriggerType { get; set; }

    [JsonProperty("trigger_metadata")]
    public required AutoMorderationTriggerMetadata TriggerMetadata { get; set; }

    [JsonProperty("actions")]
    public required AutoModerationAction[] Actions { get; set; }

    [JsonProperty("enabled")]
    public bool Enabled { get; set; }

    [JsonProperty("exempt_roles")]
    public required string[] ExemptRoles { get; set; }

    [JsonProperty("exempt_channels")]
    public required string[] ExemptChannels { get; set; }
}