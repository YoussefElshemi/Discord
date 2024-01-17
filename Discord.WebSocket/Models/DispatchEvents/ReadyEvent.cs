using Newtonsoft.Json;

namespace Discord.Models.DispatchEvents;

public class ReadyEvent
{
    [JsonProperty("v")]
    public required string Version { get; set; }

    [JsonProperty("user")]
    public required User User { get; set; }

    [JsonProperty("guilds")]
    public required UnavailableGuild[] Guilds { get; set; }

    [JsonProperty("session_id")]
    public required string SessionId { get; set; }

    [JsonProperty("resume_gateway_url")]
    public required string ResumeGatewayUrl { get; set; }

    [JsonProperty("shard")]
    public int[]? Shard { get; set; }
}