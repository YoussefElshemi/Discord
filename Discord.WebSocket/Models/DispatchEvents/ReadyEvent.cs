using Newtonsoft.Json;

namespace Discord.Models.DispatchEvents;

public class ReadyEvent
{
    [JsonProperty("v")]
    public string Version { get; set; } = null!;

    [JsonProperty("user")]
    public User User { get; set; } = null!;

    [JsonProperty("guilds")]
    public UnavailableGuild[] Guilds { get; set; } = null!;

    [JsonProperty("session_id")]
    public string SessionId { get; set; } = null!;

    [JsonProperty("resume_gateway_url")]
    public string ResumeGatewayUrl { get; set; } = null!;

    [JsonProperty("shard")]
    public int[]? Shard { get; set; }
}