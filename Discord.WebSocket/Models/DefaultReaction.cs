using Newtonsoft.Json;

namespace Discord.Models;

public class DefaultReaction
{
    [JsonProperty("emoji_id")]
    public string? EmojiId { get; set; }

    [JsonProperty("emoji_name")]
    public string? EmojiName { get; set; }
}