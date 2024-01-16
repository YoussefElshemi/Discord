using Newtonsoft.Json;

namespace Discord.Models;

public class RoleTag
{
    [JsonProperty("bot_id")]
    public string? BotId { get; set; }
    
    [JsonProperty("integration_id")]
    public string? IntegrationId { get; set; }
    
    [JsonProperty("premium_subscriber")]
    public object? PremiumSubscriber { get; set; }
    
    [JsonProperty("subscription_listing_id")]
    public string? SubscriptionListingId { get; set; }
    
    [JsonProperty("available_for_purchase")]
    public object? AvailableForPurchase { get; set; }
    
    [JsonProperty("guild_connections")]
    public object? GuildConnections { get; set; }
}