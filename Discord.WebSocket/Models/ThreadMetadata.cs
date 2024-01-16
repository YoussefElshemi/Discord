﻿using Newtonsoft.Json;

namespace Discord.Models;

public class ThreadMetadata
{
    [JsonProperty("archived")]
    public bool Archived { get; set; }

    [JsonProperty("auto_archive_duration")]
    public int AutoArchiveDuration { get; set; }

    [JsonProperty("archive_timestamp")]
    public DateTime? ArchiveTimestamp { get; set; }

    [JsonProperty("locked")]
    public bool Locked { get; set; }

    [JsonProperty("invitable")]
    public bool? Invitable { get; set; }

    [JsonProperty("create_timestamp")]
    public DateTime? CreateTimestamp { get; set; }
}