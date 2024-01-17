using Newtonsoft.Json;

namespace Discord.Models;

public class GuildApplicationCommandPermissions
{
    [JsonProperty("id")]
    public required string Id { get; set; }

    [JsonProperty("application_id")]
    public required string ApplicationId { get; set; }

    [JsonProperty("guild_id")]
    public required string GuildId { get; set; }

    [JsonProperty("permissions")]
    public required ApplicationCommandPermission[] Permissions { get; set; }
}