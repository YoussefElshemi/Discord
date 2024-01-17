using Newtonsoft.Json;

namespace Discord.Models;

public class ResumeData
{
    [JsonProperty("token")]
    public string Token { get; set; } = null!;

    [JsonProperty("session_id")]
    public string SessionId { get; set; } = null!;

    [JsonProperty("seq")]
    public int Seq { get; set; }
}