namespace Discord.Models;

public class ClientEventArgs<T> : EventArgs
{
    public required T Event { get; set; }
}