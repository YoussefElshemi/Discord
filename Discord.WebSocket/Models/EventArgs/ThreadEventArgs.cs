using Discord.Models.DispatchEvents;

namespace Discord.Models.EventArgs;

public class ThreadEventArgs : System.EventArgs
{
    public required ThreadEvent Event { get; set; }
}