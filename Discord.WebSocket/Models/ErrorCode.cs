namespace Discord.Models;

public class ErrorCode(int code, string description, string explanation, bool reconnect)
{
    public int Code { get; set; } = code;
    public string Description { get; set; } = description;
    public string Explanation { get; set; } = explanation;
    public bool Reconnect { get; set; } = reconnect;
}