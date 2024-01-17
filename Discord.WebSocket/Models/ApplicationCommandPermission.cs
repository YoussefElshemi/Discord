using Discord.Enums;
using Newtonsoft.Json;

namespace Discord.Models;

public class ApplicationCommandPermission
{
    [JsonProperty("id")]
    public required string Id { get; set; }

    [JsonProperty("type")]
    public ApplicationCommandPermissionType Type { get; set; }

    [JsonProperty("permission")]
    public bool Permission { get; set; }
}