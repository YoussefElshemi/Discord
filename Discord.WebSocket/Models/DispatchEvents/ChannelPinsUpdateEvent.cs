using Newtonsoft.Json;

namespace Discord.Models.DispatchEvents;

public class ChannelPinsUpdateEvent
{
    [JsonProperty("guild_id")]
    public string? GuildId { get; set; }

    [JsonProperty("channel_id")]
    public required string ChannelId { get; set; }

    [JsonProperty("last_pin_timestamp")]
    public DateTime? LastPinTimestamp { get; set; }
}