using Newtonsoft.Json;

namespace Discord.Models;

public class PermissionOverwrite
{
    [JsonProperty("id")]
    public required string Id { get; set; }

    [JsonProperty("type")]
    public int Type { get; set; }

    [JsonProperty("allow")]
    public required string Allow { get; set; }

    [JsonProperty("deny")]
    public required string Deny { get; set; }
}