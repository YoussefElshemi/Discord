using Newtonsoft.Json;

namespace Discord.Models.DispatchEvents;

public class ThreadMembersUpdateEvent
{
    [JsonProperty("id")]
    public required string Id { get; set; }

    [JsonProperty("guild_id")]
    public required string GuildId { get; set; }

    [JsonProperty("member_count")]
    public int MemberCount { get; set; }

    [JsonProperty("added_members")]
    public ThreadMember[]? AddedMembers { get; set; }

    [JsonProperty("removed_member_ids")]
    public string[]? RemovedMemberIds { get; set; }
}