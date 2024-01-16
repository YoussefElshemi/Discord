using Newtonsoft.Json;

namespace Discord.Models;

public class UnavailableGuild
{
    [JsonProperty("id")]
    public string Id { get; set; } = null!;
    
    [JsonProperty("unavailable")]
    public bool? Unavailable { get; set; }
}