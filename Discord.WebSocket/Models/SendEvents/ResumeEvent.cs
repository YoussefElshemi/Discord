﻿using Discord.Enums;
using Discord.Models.Dtos;
using Newtonsoft.Json;

namespace Discord.Models.SendEvents;

public class ResumeEvent : BaseEventDto
{
    [JsonProperty("d")] 
    public ResumeData Data { get; set; } = new();
    
    public ResumeEvent()
    {
        OpCode = OpCode.Resume;
    }
}

public class ResumeData
{
    [JsonProperty("token")]
    public string Token { get; set; } = null!;
    
    [JsonProperty("session_id")]
    public string SessionId { get; set; } = null!;

    [JsonProperty("seq")] 
    public int Seq { get; set; }
}