using Discord.Models.DispatchEvents;

namespace Discord.Models.EventArgs;

public class ThreadMembersUpdateEventArgs : System.EventArgs
{
    public required ThreadMembersUpdateEvent Event { get; set; }
}