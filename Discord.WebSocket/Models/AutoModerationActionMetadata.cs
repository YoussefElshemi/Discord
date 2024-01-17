using Newtonsoft.Json;

namespace Discord.Models;

public class AutoModerationActionMetadata
{
    [JsonProperty("channel_id")]
    public string? ChannelId { get; set; }

    [JsonProperty("duration_seconds")]
    public int? DurationSeconds { get; set; }

    [JsonProperty("custom_message")]
    public string? CustomMessage { get; set; }
}