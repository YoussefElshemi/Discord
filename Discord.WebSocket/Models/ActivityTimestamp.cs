using Newtonsoft.Json;

namespace Discord.Models;

public class ActivityTimestamp
{
    [JsonProperty("start")]
    public int? Start { get; set; }

    [JsonProperty("end")]
    public int? End { get; set; }
}