using Newtonsoft.Json;

namespace Discord.Models.DispatchEvents;

public class ThreadMemberUpdateEvent : ThreadMember
{
    [JsonProperty("guild_id")]
    public required string GuildId { get; set; }
}