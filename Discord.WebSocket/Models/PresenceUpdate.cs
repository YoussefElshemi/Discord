using Newtonsoft.Json;

namespace Discord.Models;

public class PresenceUpdate
{
    [JsonProperty("user")]
    public User User { get; set; } = null!;

    [JsonProperty("guild_id")]
    public string GuildId { get; set; } = null!;

    [JsonProperty("status")]
    public string Status { get; set; } = null!;

    [JsonProperty("activities")]
    public Activity[] Activities { get; set; } = null!;

    [JsonProperty("client_status")]
    public ClientStatus ClientStatus { get; set; } = null!;
}