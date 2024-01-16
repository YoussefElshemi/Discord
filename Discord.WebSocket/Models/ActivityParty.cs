using Newtonsoft.Json;

namespace Discord.Models;

public class ActivityParty
{
    [JsonProperty("id")]
    public string? Id { get; set; }

    [JsonProperty("size")]
    public int[]? Size { get; set; }
}