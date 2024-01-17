using Discord.Models.Dtos;
using Newtonsoft.Json;

namespace Discord.Models.ReceiveEvents;

public class InvalidSessionEvent : BaseEventDto
{
    [JsonProperty("d")]
    public bool? Data { get; set; }
}