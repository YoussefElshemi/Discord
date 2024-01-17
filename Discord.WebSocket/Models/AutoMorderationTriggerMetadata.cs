using Discord.Enums;
using Newtonsoft.Json;

namespace Discord.Models;

public class AutoMorderationTriggerMetadata
{
    [JsonProperty("keyword_filter")]
    public required string[] KeywordFilter { get; set; }

    [JsonProperty("regex_patterns")]
    public required string[] RegexPatterns { get; set; }

    [JsonProperty("presets")]
    public required AutoModerationKeywordPresetType[] Presets { get; set; }

    [JsonProperty("allow_list")]
    public required string[] AllowList { get; set; }

    [JsonProperty("mention_total_limit")]
    public int MentionTotalLimit { get; set; }

    [JsonProperty("mention_raid_protection_enabled")]
    public bool MentionRaidProtectionEnabled { get; set; }
}