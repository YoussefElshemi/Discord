using Newtonsoft.Json;

namespace Discord.Models;

public class GuildScheduledEventEntityMetadata
{
    [JsonProperty("location")]
    public string? Location { get; set; }
}