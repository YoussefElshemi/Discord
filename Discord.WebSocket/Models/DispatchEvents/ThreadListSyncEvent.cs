using Newtonsoft.Json;

namespace Discord.Models.DispatchEvents;

public class ThreadListSyncEvent
{
    [JsonProperty("guild_id")]
    public required string GuildId { get; set; }

    [JsonProperty("channel_ids")]
    public string[]? ChannelIds { get; set; }

    [JsonProperty("threads")]
    public required Channel[] Threads { get; set; }

    [JsonProperty("members")]
    public required ThreadMember[] Members { get; set; }
}