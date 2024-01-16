using Newtonsoft.Json;

namespace Discord.Models;

public class Activity
{
    [JsonProperty("name")]
    public string Name { get; set; } = null!;

    [JsonProperty("type")]
    public int Type { get; set; }

    [JsonProperty("url")]
    public string? Url { get; set; }

    [JsonProperty("created_at")]
    public int CreatedAt { get; set; }

    [JsonProperty("timestamps")]
    public ActivityTimestamp[]? Timestamps { get; set; }

    [JsonProperty("application_id")]
    public string? ApplicationId { get; set; }

    [JsonProperty("details")]
    public string? Details { get; set; }

    [JsonProperty("state")]
    public string? State { get; set; }

    [JsonProperty("emoji")]
    public Emoji? Emoji { get; set; }

    [JsonProperty("party")]
    public ActivityParty? Party { get; set; }

    [JsonProperty("assets")]
    public ActivityAssets? Assets { get; set; }

    [JsonProperty("secrets")]
    public ActivitySecrets? Secrets { get; set; }

    [JsonProperty("instance")]
    public bool? Instance { get; set; }

    [JsonProperty("flags")]
    public int? Flags { get; set; }

    [JsonProperty("buttons")]
    public ActivityButton[]? Buttons { get; set; }
}