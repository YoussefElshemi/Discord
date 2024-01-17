using Newtonsoft.Json;

namespace Discord.Models;

public class IdentifyProperties
{
    [JsonProperty("os")]
    public string Os { get; set; } = "windows";

    [JsonProperty("browser")]
    public string Browser { get; set; } = "my_library";

    [JsonProperty("device")]
    public string Device { get; set; } = "my_library";
}