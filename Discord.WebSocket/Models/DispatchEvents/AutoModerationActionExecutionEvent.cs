using Discord.Enums;
using Newtonsoft.Json;

namespace Discord.Models.DispatchEvents;

public class AutoModerationActionExecutionEvent
{
    [JsonProperty("guild_id")]
    public required string GuildId { get; set; }

    [JsonProperty("action")]
    public required AutoModerationAction Action { get; set; }

    [JsonProperty("rule_id")]
    public required string RuleId { get; set; }

    [JsonProperty("rule_trigger_type")]
    public AutoModerationTriggerType TriggerType { get; set; }

    [JsonProperty("user_id")]
    public required string UserId { get; set; }

    [JsonProperty("channel_id")]
    public string? ChannelId { get; set; }

    [JsonProperty("message_id")]
    public string? MessageId { get; set; }

    [JsonProperty("alert_system_message_id")]
    public string? AlertSystemMessageId { get; set; }

    [JsonProperty("content")]
    public required string Content { get; set; }

    [JsonProperty("matched_keyword")]
    public string? MatchedKeyword { get; set; }

    [JsonProperty("matched_content")]
    public string? MatchedContent { get; set; }
}