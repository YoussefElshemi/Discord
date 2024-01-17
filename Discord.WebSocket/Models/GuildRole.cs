using Newtonsoft.Json;

namespace Discord.Models;

public class GuildRole
{
    [JsonProperty("id")]
    public required string Id { get; set; }

    [JsonProperty("name")]
    public required string Name { get; set; }

    [JsonProperty("color")]
    public int Color { get; set; }

    [JsonProperty("hoist")]
    public bool Hoist { get; set; }

    [JsonProperty("icon")]
    public string? Icon { get; set; }

    [JsonProperty("unicode_emoji")]
    public string? UnicodeEmoji { get; set; }

    [JsonProperty("position")]
    public int Position { get; set; }

    [JsonProperty("permissions")]
    public required string Permissions { get; set; }

    [JsonProperty("managed")]
    public bool Managed { get; set; }

    [JsonProperty("mentionable")]
    public bool Mentionable { get; set; }

    [JsonProperty("tags")]
    public required RoleTag Tags { get; set; }

    [JsonProperty("flags")]
    public int Flags { get; set; }
}