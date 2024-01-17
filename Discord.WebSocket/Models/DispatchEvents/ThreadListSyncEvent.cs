using Newtonsoft.Json;

namespace Discord.Models.DispatchEvents;

public class ThreadListSyncEvent
{
    [JsonProperty("guild_id")]
    public string GuildId { get; set; }

    [JsonProperty("channel_ids")]
    public string[]? ChannelIds { get; set; }

    [JsonProperty("threads")]
    public Channel[] Threads { get; set; }

    [JsonProperty("members")]
    public ThreadMember[] Members { get; set; }
}