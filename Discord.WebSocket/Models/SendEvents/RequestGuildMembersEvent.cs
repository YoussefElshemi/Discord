using Discord.Enums;
using Discord.Models.Dtos;
using Newtonsoft.Json;

namespace Discord.Models.SendEvents;

public class RequestGuildMembersEvent : BaseEventDto
{

    public RequestGuildMembersEvent()
    {
        OpCode = OpCode.RequestGuildMembers;
    }

    [JsonProperty("d")]
    public RequestGuildMembersData Data { get; set; } = new();
}