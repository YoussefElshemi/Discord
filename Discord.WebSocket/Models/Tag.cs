using Newtonsoft.Json;

namespace Discord.Models;

public class Tag
{
    [JsonProperty("id")]
    public string Id { get; set; } = null!;

    [JsonProperty("name")]
    public string Name { get; set; } = null!;

    [JsonProperty("moderated")]
    public bool Moderated { get; set; }

    [JsonProperty("emoji_id")]
    public string? EmojiId { get; set; }

    [JsonProperty("emoji_name")]
    public string? EmojiName { get; set; }
}