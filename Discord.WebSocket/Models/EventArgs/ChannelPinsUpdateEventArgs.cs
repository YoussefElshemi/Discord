using Discord.Models.DispatchEvents;

namespace Discord.Models.EventArgs;

public class ChannelPinsUpdateEventArgs : System.EventArgs
{
    public required ChannelPinsUpdateEvent Event { get; set; }
}