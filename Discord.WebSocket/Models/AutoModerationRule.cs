using Discord.Enums;
using Newtonsoft.Json;

namespace Discord.Models;

public class AutoModerationRule
{
    [JsonProperty("id")]
    public string Id { get; set; } = null!;

    [JsonProperty("guild_id")]
    public string GuildId { get; set; } = null!;

    [JsonProperty("name")]
    public string Name { get; set; } = null!;

    [JsonProperty("creator_id")]
    public string CreatorId { get; set; } = null!;

    [JsonProperty("event_type")]
    public AutoModerationEventType EventType { get; set; }

    [JsonProperty("trigger_type")]
    public AutoModerationTriggerType TriggerType { get; set; }

    [JsonProperty("trigger_metadata")]
    public AutoMorderationTriggerMetadata TriggerMetadata { get; set; }

    [JsonProperty("actions")]
    public AutoModerationAction[] Actions { get; set; } = null!;

    [JsonProperty("enabled")]
    public bool Enabled { get; set; }

    [JsonProperty("exempt_roles")]
    public string[] ExemptRoles { get; set; } = null!;

    [JsonProperty("exempt_channels")]
    public string[] ExemptChannels { get; set; } = null!;
}