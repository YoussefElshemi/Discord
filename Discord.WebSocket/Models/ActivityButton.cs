using Newtonsoft.Json;

namespace Discord.Models;

public class ActivityButton
{
    [JsonProperty("label")]
    public string Label { get; set; } = null!;

    [JsonProperty("url")]
    public string Url { get; set; } = null!;


}