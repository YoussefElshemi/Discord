using System.Net.WebSockets;
using Discord.Models;

namespace Discord.Helpers;

public static class ErrorCodeHelper
{
    private static readonly Dictionary<int, ErrorCode> ErrorCodes = new()
    {
        { 4000, new ErrorCode(4000, "Unknown error", "We're not sure what went wrong. Try reconnecting?", true) },
        { 4001, new ErrorCode(4001, "Unknown opcode", "You sent an invalid Gateway opcode or an invalid payload for an opcode. Don't do that!", true) },
        { 4002, new ErrorCode(4002, "Decode error", "You sent an invalid payload to Discord.WebSocket. Don't do that!", true) },
        { 4003, new ErrorCode(4003, "Not authenticated", "You sent us a payload prior to identifying.", true) },
        { 4004, new ErrorCode(4004, "Authentication failed", "The account token sent with your identify payload is incorrect.", false) },
        { 4005, new ErrorCode(4005, "Already authenticated", "You sent more than one identify payload. Don't do that!", true) },
        { 4007, new ErrorCode(4007, "Invalid seq", "The sequence sent when resuming the session was invalid. Reconnect and start a new session.", true) },
        { 4008, new ErrorCode(4008, "Rate limited", "Woah nelly! You're sending payloads to us too quickly. Slow it down! You will be disconnected on receiving this.", true) },
        { 4009, new ErrorCode(4009, "Session timed out", "Your session timed out. Reconnect and start a new one.", true) },
        { 4010, new ErrorCode(4010, "Invalid shard", "You sent us an invalid shard when identifying.", false) },
        { 4011, new ErrorCode(4011, "Sharding required", "The session would have handled too many guilds - you are required to shard your connection in order to connect.", false) },
        { 4012, new ErrorCode(4012, "Invalid API version", "You sent an invalid version for the gateway.", false) },
        { 4013, new ErrorCode(4013, "Invalid intent(s)", "You sent an invalid intent for a Gateway Intent. You may have incorrectly calculated the bitwise value.", false) },
        { 4014, new ErrorCode(4014, "Disallowed intent(s)", "You sent a disallowed intent for a Gateway Intent. You may have tried to specify an intent that you have not enabled or are not approved for.", false) }
    };

    public static ErrorCode? GetErrorCodeDetails(WebSocketCloseStatus code)
    {
        if (ErrorCodes.TryGetValue((int)code, out var errorCode))
        {
            return errorCode;
        }

        Console.WriteLine($"Error code {code} not found.");
        return null;
    }
}