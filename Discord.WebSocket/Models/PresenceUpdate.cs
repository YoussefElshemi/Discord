using Newtonsoft.Json;

namespace Discord.Models;

public class PresenceUpdate
{
    [JsonProperty("user")]
    public required User User { get; set; }

    [JsonProperty("guild_id")]
    public required string GuildId { get; set; }

    [JsonProperty("status")]
    public required string Status { get; set; }

    [JsonProperty("activities")]
    public required Activity[] Activities { get; set; }

    [JsonProperty("client_status")]
    public required ClientStatus ClientStatus { get; set; }
}