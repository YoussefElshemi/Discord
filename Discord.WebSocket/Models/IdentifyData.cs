using Newtonsoft.Json;

namespace Discord.Models;

public class IdentifyData
{
    [JsonProperty("token")]
    public required string Token { get; set; }

    [JsonProperty("properties")]
    public IdentifyProperties Properties { get; set; } = new();

    [JsonProperty("compress", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public bool? Compress { get; set; } = false;

    [JsonProperty("large_threshold", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public int? LargeThreshold { get; set; } = 50;

    [JsonProperty("shard", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public int[]? Shard { get; set; }

    [JsonProperty("presence", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public UpdatePresenceData? Presence { get; set; }

    [JsonProperty("intents")]
    public int Intents { get; set; } = 513;
}