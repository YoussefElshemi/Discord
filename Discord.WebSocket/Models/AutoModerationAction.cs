using Discord.Enums;
using Newtonsoft.Json;

namespace Discord.Models;

public class AutoModerationAction
{
    [JsonProperty("type")]
    public ActionType Type { get; set; }

    [JsonProperty("metadata")]
    public ActionMetadata? Metadata { get; set; }
}