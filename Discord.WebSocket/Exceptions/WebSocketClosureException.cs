using System.Net.WebSockets;

namespace Discord.Exceptions;

public class WebSocketClosureException : Exception
{
    public WebSocketClosureException()
    {
    }
    
    public WebSocketClosureException(WebSocketCloseStatus? code)
        : base($@"{code} - Unknown WebSocket Error") { }

    public WebSocketClosureException(WebSocketCloseStatus? code, string description, string explanation)
        : base($@"{code} - {description}: {explanation}") { }
}