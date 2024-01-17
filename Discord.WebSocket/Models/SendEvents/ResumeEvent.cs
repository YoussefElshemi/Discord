using Discord.Enums;
using Discord.Models.Dtos;
using Newtonsoft.Json;

namespace Discord.Models.SendEvents;

public class ResumeEvent : BaseEventDto
{
    public ResumeEvent()
    {
        OpCode = OpCode.Resume;
    }

    [JsonProperty("d")]
    public required ResumeData Data { get; set; }
}