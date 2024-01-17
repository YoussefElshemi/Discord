using Discord.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Discord.Models;

public class UpdatePresenceData
{
    [JsonProperty("since")]
    public int? Since { get; set; }

    [JsonProperty("activities")]
    public required Activity[] Activities { get; set; }

    [JsonProperty("status")]
    [JsonConverter(typeof(StringEnumConverter))]
    public PresenceStatus Status { get; set; }

    [JsonProperty("afk")]
    public bool Afk { get; set; }
}