using Discord.Enums;
using Discord.Models.Dtos;
using Newtonsoft.Json;

namespace Discord.Models.SendEvents;

public class IdentifyEvent : BaseEventDto
{
    public IdentifyEvent()
    {
        OpCode = OpCode.Identify;
    }

    [JsonProperty("d")]
    public IdentifyData Data { get; set; } = new();
}

public class IdentifyData
{
    [JsonProperty("token")]
    public string Token { get; set; } = null!;

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

public class IdentifyProperties
{
    [JsonProperty("os")]
    public string Os { get; set; } = "windows";

    [JsonProperty("browser")]
    public string Browser { get; set; } = "my_library";

    [JsonProperty("device")]
    public string Device { get; set; } = "my_library";
}