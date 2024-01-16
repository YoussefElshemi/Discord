using Newtonsoft.Json;

namespace Discord.Models.Dtos;

public class WebsocketMessageDto : BaseEventDto
{    
    [JsonProperty("d")]
    public object? Data { get; set; }
}