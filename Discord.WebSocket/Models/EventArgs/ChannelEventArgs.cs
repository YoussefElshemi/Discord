using Discord.Models.DispatchEvents;

namespace Discord.Models.EventArgs;

public class ChannelEventArgs : System.EventArgs
{
    public required ChannelEvent Event { get; set; }
}