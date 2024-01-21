using Discord.Models.DispatchEvents;

namespace Discord.Models.EventArgs;

public class ThreadListSyncEventArgs : System.EventArgs
{
    public required ThreadListSyncEvent Event { get; set; }
}