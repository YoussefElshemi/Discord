using Discord.Enums;
using Newtonsoft.Json;

namespace Discord.Models.Dtos;

public class BaseEventDto
{
    [JsonProperty("op")]
    public OpCode OpCode { get; set; }

    [JsonProperty("s")]
    public int? SequenceNumber { get; set; }

    [JsonProperty("t")]
    public string? EventName { get; set; }
}