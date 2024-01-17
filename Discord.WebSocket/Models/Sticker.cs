using Newtonsoft.Json;

namespace Discord.Models;

public class Sticker
{
    [JsonProperty("id")]
    public string? Id { get; set; }

    [JsonProperty("pack_id")]
    public string? PackId { get; set; }

    [JsonProperty("name")]
    public required string Name { get; set; }

    [JsonProperty("description")]
    public string? Description { get; set; }

    [JsonProperty("tags")]
    public required string Tags { get; set; }

    [JsonProperty("asset")]
    public string? Asset { get; set; }

    [JsonProperty("type")]
    public int Type { get; set; }

    [JsonProperty("format_type")]
    public int FormatType { get; set; }

    [JsonProperty("available")]
    public bool? Available { get; set; }

    [JsonProperty("guild_id")]
    public string? GuildId { get; set; }

    [JsonProperty("user")]
    public User? User { get; set; }

    [JsonProperty("sort_value")]
    public int SortValue { get; set; }
}