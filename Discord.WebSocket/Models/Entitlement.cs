using Discord.Enums;
using Newtonsoft.Json;

namespace Discord.Models;

public class Entitlement
{
    [JsonProperty("id")]
    public required string Id { get; set; }

    [JsonProperty("sku_id")]
    public required string SkuId { get; set; }

    [JsonProperty("application_id")]
    public required string ApplicationId { get; set; }

    [JsonProperty("user_id")]
    public string? UserId { get; set; }

    [JsonProperty("type")]
    public EntitlementType Type { get; set; }

    [JsonProperty("deleted")]
    public bool Deleted { get; set; }

    [JsonProperty("starts_at")]
    public DateTime? StartsAt { get; set; }

    [JsonProperty("ends_at")]
    public DateTime? EndsAt { get; set; }

    [JsonProperty("guild_id")]
    public string? GuildId { get; set; }
}