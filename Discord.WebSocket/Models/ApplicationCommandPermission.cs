using Discord.Enums;
using Newtonsoft.Json;

namespace Discord.Models;

public class ApplicationCommandPermission
{
    [JsonProperty("id")]
    public string Id { get; set; } = null!;

    [JsonProperty("type")]
    public ApplicationCommandPermissionType Type { get; set; }

    [JsonProperty("permission")]
    public bool Permission { get; set; }
}