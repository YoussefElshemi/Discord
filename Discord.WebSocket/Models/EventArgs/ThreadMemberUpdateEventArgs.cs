using Discord.Models.DispatchEvents;

namespace Discord.Models.EventArgs;

public class ThreadMemberUpdateEventArgs : System.EventArgs
{
    public required ThreadMemberUpdateEvent Event { get; set; }
}