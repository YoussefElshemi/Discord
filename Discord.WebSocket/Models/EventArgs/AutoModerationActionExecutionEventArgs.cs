using Discord.Models.DispatchEvents;

namespace Discord.Models.EventArgs;

public class AutoModerationActionExecutionEventArgs : System.EventArgs
{
    public required AutoModerationActionExecutionEvent Event { get; set; }
}