using Discord.Models.DispatchEvents;

namespace Discord.Models.EventArgs;

public class GuildApplicationCommandPermissionsUpdateEventArgs : System.EventArgs
{
    public required GuildApplicationCommandPermissionsUpdateEvent Event { get; set; }
}