using Newtonsoft.Json;

namespace Discord.Models;

public class WelcomeScreen
{
    [JsonProperty("channel_id")]
    public string ChannelId { get; set; } = null!;

    [JsonProperty("description")]
    public string Description { get; set; } = null!;

    [JsonProperty("emoji_id")]
    public string EmojiId { get; set; } = null!;

    [JsonProperty("emoji_name")]
    public string EmojiName { get; set; } = null!;
}