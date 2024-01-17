using Newtonsoft.Json;

namespace Discord.Models;

public class GuildApplicationCommandPermissions
{
    [JsonProperty("id")]
    public string Id { get; set; } = null!;

    [JsonProperty("application_id")]
    public string ApplicationId { get; set; } = null!;

    [JsonProperty("guild_id")]
    public string GuildId { get; set; } = null!;

    [JsonProperty("permissions")]
    public ApplicationCommandPermission[] Permissions { get; set; }
}