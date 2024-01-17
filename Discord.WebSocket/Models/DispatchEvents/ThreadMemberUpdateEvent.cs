using Newtonsoft.Json;

namespace Discord.Models.DispatchEvents;

public class ThreadMemberUpdateEvent : ThreadMember
{
    [JsonProperty("guild_id")]
    public string GuildId { get; set; } = null!;
}