using Newtonsoft.Json;

namespace Discord.Models;

public class ActivityButton
{
    [JsonProperty("label")]
    public required string Label { get; set; }

    [JsonProperty("url")]
    public required string Url { get; set; }
}