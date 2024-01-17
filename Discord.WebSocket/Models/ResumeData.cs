using Newtonsoft.Json;

namespace Discord.Models;

public class ResumeData
{
    [JsonProperty("token")]
    public required string Token { get; set; }

    [JsonProperty("session_id")]
    public required string SessionId { get; set; }

    [JsonProperty("seq")]
    public int Seq { get; set; }
}