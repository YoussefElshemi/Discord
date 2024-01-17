using Newtonsoft.Json;

namespace Discord.Models;

public class WelcomeScreen
{
    [JsonProperty("channel_id")]
    public required string ChannelId { get; set; }

    [JsonProperty("description")]
    public required string Description { get; set; }

    [JsonProperty("emoji_id")]
    public required string EmojiId { get; set; }

    [JsonProperty("emoji_name")]
    public required string EmojiName { get; set; }
}