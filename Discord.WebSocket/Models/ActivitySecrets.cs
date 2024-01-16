using Newtonsoft.Json;

namespace Discord.Models;

public class ActivitySecrets
{
    [JsonProperty("join")]
    public string? Join { get; set; }

    [JsonProperty("spectate")]
    public string? Spectate { get; set; }

    [JsonProperty("match")]
    public string? Match { get; set; }
}