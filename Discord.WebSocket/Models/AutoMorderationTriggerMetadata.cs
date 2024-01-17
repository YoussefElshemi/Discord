using Discord.Enums;
using Newtonsoft.Json;

namespace Discord.Models;

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