using Discord.Models.DispatchEvents;

namespace Discord.Models.EventArgs;

public class GuildCreateEventArgs : System.EventArgs
{
    public required GuildCreateEvent Event { get; set; }
}