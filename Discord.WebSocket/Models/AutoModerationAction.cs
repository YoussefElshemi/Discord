using Discord.Enums;
using Newtonsoft.Json;

namespace Discord.Models;

public class AutoModerationAction
{
    [JsonProperty("type")]
    public AutoModerationActionType Type { get; set; }

    [JsonProperty("metadata")]
    public AutoModerationActionMetadata? Metadata { get; set; }
}