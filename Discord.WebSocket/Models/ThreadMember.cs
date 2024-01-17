using Newtonsoft.Json;

namespace Discord.Models;

public class ThreadMember
{
    [JsonProperty("id")]
    public string? Id { get; set; }

    [JsonProperty("user_id")]
    public string? UserId { get; set; }

    [JsonProperty("join_timestamp")]
    public DateTime JoinTimestamp { get; set; }

    [JsonProperty("flags")]
    public int Flags { get; set; }

    [JsonProperty("member")]
    public GuildMember? Member { get; set; }
}