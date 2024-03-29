﻿using Discord.Enums;
using Discord.Models.Dtos;
using Newtonsoft.Json;

namespace Discord.Models.SendEvents;

public class IdentifyEvent : BaseEventDto
{
    public IdentifyEvent()
    {
        OpCode = OpCode.Identify;
    }

    [JsonProperty("d")]
    public required IdentifyData Data { get; set; }
}