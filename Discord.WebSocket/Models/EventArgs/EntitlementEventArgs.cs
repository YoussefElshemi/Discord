using Discord.Models.DispatchEvents;

namespace Discord.Models.EventArgs;

public class EntitlementEventArgs : System.EventArgs
{
    public required EntitlementEvent Event { get; set; }
}