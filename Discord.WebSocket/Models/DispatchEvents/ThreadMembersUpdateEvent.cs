using Newtonsoft.Json;

namespace Discord.Models.DispatchEvents;

public class ThreadMembersUpdateEvent
{
    [JsonProperty("id")]
    public string Id { get; set; } = null!;

    [JsonProperty("guild_id")]
    public string GuildId { get; set; } = null!;

    [JsonProperty("member_count")]
    public int MemberCount { get; set; }

    [JsonProperty("added_members")]
    public ThreadMember[]? AddedMembers { get; set; }

    [JsonProperty("removed_member_ids")]
    public string[]? RemovedMemberIds { get; set; }
}