namespace Discord.Models;

public class ClientEventArgs<T> : EventArgs
{
    public required T Event { get; init; }
    public required Client Client { get; set; }
}