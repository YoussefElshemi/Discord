using Discord.Enums;
using Discord.Models.Dtos;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Discord.Models.SendEvents;

public class UpdatePresenceEvent : BaseEventDto
{
    public UpdatePresenceEvent()
    {
        OpCode = OpCode.PresenceUpdate;
    }

    [JsonProperty("d")]
    public UpdatePresenceData Data { get; set; } = new();
}

public class UpdatePresenceData
{
    [JsonProperty("since")]
    public int? Since { get; set; }

    [JsonProperty("activities")]
    public Activity[] Activities { get; set; } = null!;

    [JsonProperty("status")]
    [JsonConverter(typeof(StringEnumConverter))]
    public Status Status { get; set; }

    [JsonProperty("afk")]
    public bool Afk { get; set; }
}