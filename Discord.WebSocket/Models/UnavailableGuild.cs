using Newtonsoft.Json;

namespace Discord.Models;

public class UnavailableGuild
{
    [JsonProperty("id")]
    public required string Id { get; set; }

    [JsonProperty("unavailable")]
    public bool? Unavailable { get; set; }
}