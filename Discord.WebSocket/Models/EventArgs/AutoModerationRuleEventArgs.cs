using Discord.Models.DispatchEvents;

namespace Discord.Models.EventArgs;

public class AutoModerationRuleEventArgs : System.EventArgs
{
    public required AutoModerationRuleEvent Event { get; set; }
}