using Newtonsoft.Json;

namespace Discord.Models;

public class PermissionOverwrite
{
    [JsonProperty("id")]
    public string Id { get; set; } = null!;

    [JsonProperty("type")]
    public int Type { get; set; }
    
    [JsonProperty("allow")]
    public string Allow { get; set; } = null!;
    
    [JsonProperty("deny")]
    public string Deny { get; set; } = null!;
}