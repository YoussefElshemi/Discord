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
    public List<AutoModerationAction> Actions { get; set; } = null!;

    [JsonProperty("enabled")]
    public bool Enabled { get; set; }

    [JsonProperty("exempt_roles")]
    public List<string> ExemptRoles { get; set; } = null!;

    [JsonProperty("exempt_channels")]
    public List<string> ExemptChannels { get; set; } = null!;
}

public class AutoMorderationTriggerMetadata
{
    [JsonProperty("keyword_filter")]
    public string[] KeywordFilter { get; set; } = null!;

    [JsonProperty("regex_patterns")]
    public string[] RegexPatterns { get; set; } = null!;

    [JsonProperty("presets")]
    public AutoModerationKeywordPresetType[] Presets { get; set; } = null!;

    [JsonProperty("allow_list")]
    public string[] AllowList { get; set; } = null!;

    [JsonProperty("mention_total_limit")]
    public int MentionTotalLimit { get; set; }

    [JsonProperty("mention_raid_protection_enabled")]
    public bool MentionRaidProtectionEnabled { get; set; }
}