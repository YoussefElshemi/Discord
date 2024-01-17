﻿using Discord.Enums;
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

public class RequestGuildMembersData
{
    [JsonProperty("guild_id")]
    public string GuildId { get; set; } = null!;

    [JsonProperty("query")]
    public string? Query { get; set; }

    [JsonProperty("limit")]
    public int Limit { get; set; }

    [JsonProperty("presences")]
    public bool? Presences { get; set; }

    [JsonProperty("user_ids")]
    public dynamic? UserIds { get; set; }

    [JsonProperty("nonce")]
    public string? Nonce { get; set; }
}