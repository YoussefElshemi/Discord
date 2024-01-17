using Discord.Enums;
using Newtonsoft.Json;

namespace Discord.Models.DispatchEvents;

public class ApplicationCommandPermissionsUpdateEvent
{

    [JsonProperty("guild_id")]
    public string GuildId { get; set; } = null!;

    [JsonProperty("action")]
    public AutoModerationAction Action { get; set; } = null!;

    [JsonProperty("rule_id")]
    public string RuleId { get; set; } = null!;

    [JsonProperty("rule_trigger_type")]
    public TriggerType RuleTriggerType { get; set; }

    [JsonProperty("user_id")]
    public string UserId { get; set; } = null!;

    [JsonProperty("channel_id")]
    public string? ChannelId { get; set; }

    [JsonProperty("message_id")]
    public string? MessageId { get; set; }

    [JsonProperty("alert_system_message_id")]
    public string? AlertSystemMessageId { get; set; }

    [JsonProperty("content")]
    public string Content { get; set; } = null!;

    [JsonProperty("matched_keyword")]
    public string? MatchedKeyword { get; set; }

    [JsonProperty("matched_content")]
    public string? MatchedContent { get; set; }
}