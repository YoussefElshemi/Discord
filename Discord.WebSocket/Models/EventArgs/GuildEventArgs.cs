using Discord.Models.DispatchEvents;

namespace Discord.Models.EventArgs;

public class GuildEventArgs : System.EventArgs
{
    public required GuildEvent Event { get; set; }
}