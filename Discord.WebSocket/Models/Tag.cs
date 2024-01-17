using Newtonsoft.Json;

namespace Discord.Models;

public class Tag
{
    [JsonProperty("id")]
    public required string Id { get; set; }

    [JsonProperty("name")]
    public required string Name { get; set; }

    [JsonProperty("moderated")]
    public bool Moderated { get; set; }

    [JsonProperty("emoji_id")]
    public string? EmojiId { get; set; }

    [JsonProperty("emoji_name")]
    public string? EmojiName { get; set; }
}