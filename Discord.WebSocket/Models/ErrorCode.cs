namespace Discord.Models;

public class ErrorCode(int code, string description, string explanation, bool reconnect)
{
    public int Code { get; set; } = code;
    public string Description { get; } = description;
    public string Explanation { get; } = explanation;
    public bool Reconnect { get; } = reconnect;
}