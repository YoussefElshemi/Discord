using Newtonsoft.Json;

namespace Discord.Models;

public class GuildRole
{
    [JsonProperty("id")]
    public string Id { get; set; } = null!;

    [JsonProperty("name")]
    public string Name { get; set; } = null!;

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
    public string Permissions { get; set; } = null!;

    [JsonProperty("managed")]
    public bool Managed { get; set; }

    [JsonProperty("mentionable")]
    public bool Mentionable { get; set; }

    [JsonProperty("tags")]
    public RoleTag Tags { get; set; } = null!;

    [JsonProperty("flags")]
    public int Flags { get; set; }
}