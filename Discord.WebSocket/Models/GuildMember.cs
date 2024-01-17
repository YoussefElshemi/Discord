using Newtonsoft.Json;

namespace Discord.Models;

public class GuildMember
{
    [JsonProperty("user")]
    public User User { get; set; } = null!;

    [JsonProperty("nick")]
    public string? Nick { get; set; }

    [JsonProperty("avatar")]
    public string? Avatar { get; set; }

    [JsonProperty("roles")]
    public string[] Roles { get; set; } = null!;

    [JsonProperty("joined_at")]
    public DateTime JoinedAt { get; set; }

    [JsonProperty("premium_since")]
    public DateTime? PremiumSince { get; set; }

    [JsonProperty("deaf")]
    public bool Deaf { get; set; }

    [JsonProperty("mute")]
    public bool Mute { get; set; }

    [JsonProperty("flags")]
    public int Flags { get; set; }

    [JsonProperty("pending")]
    public bool? Pending { get; set; }

    [JsonProperty("permissions")]
    public string? Permissions { get; set; }

    [JsonProperty("communication_disabled_until")]
    public DateTime? CommunicationDisabledUntil { get; set; }
}