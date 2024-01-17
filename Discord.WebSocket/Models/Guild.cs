using Discord.Enums;
using Newtonsoft.Json;

namespace Discord.Models;

public class Guild : UnavailableGuild
{
    [JsonProperty("name")]
    public required string Name { get; set; }

    [JsonProperty("icon")]
    public string? Icon { get; set; }

    [JsonProperty("icon_hash")]
    public string? IconHash { get; set; }

    [JsonProperty("splash")]
    public string? Splash { get; set; }

    [JsonProperty("discovery_splash")]
    public string? DiscoverySplash { get; set; }

    [JsonProperty("owner")]
    public bool? Owner { get; set; }

    [JsonProperty("owner_id")]
    public required string OwnerId { get; set; }

    [JsonProperty("permissions")]
    public string? Permissions { get; set; }

    [JsonProperty("region")]
    public string? Region { get; set; }

    [JsonProperty("afk_channel_id")]
    public string? AfkChannelId { get; set; }

    [JsonProperty("afk_timeout")]
    public int AfkTimeout { get; set; }

    [JsonProperty("widget_enabled")]
    public bool? WidgetEnabled { get; set; }

    [JsonProperty("widget_channel_id")]
    public string? WidgetChannelId { get; set; }

    [JsonProperty("verification_level")]
    public int VerificationLevel { get; set; }

    [JsonProperty("default_message_notifications")]
    public int DefaultMessageNotifications { get; set; }

    [JsonProperty("explicit_content_filter")]
    public int ExplicitContentFilter { get; set; }

    [JsonProperty("roles")]
    public required GuildRole[] InternalRoles { get; set; }

    [JsonProperty("emojis")]
    public required Emoji[] Emojis { get; set; }

    [JsonProperty("features")]
    public required GuildFeature[] Features { get; set; }

    [JsonProperty("mfa_level")]
    public int MfaLevel { get; set; }

    [JsonProperty("application_id")]
    public string? ApplicationId { get; set; }

    [JsonProperty("system_channel_id")]
    public string? SystemChannelId { get; set; }

    [JsonProperty("system_channel_flags")]
    public int SystemChannelFlags { get; set; }

    [JsonProperty("rules_channel_id")]
    public string? RulesChannelId { get; set; }

    [JsonProperty("max_presences")]
    public int? MaxPresences { get; set; }

    [JsonProperty("max_members")]
    public int? MaxMembers { get; set; }

    [JsonProperty("vanity_url_code")]
    public string? VanityUrlCode { get; set; }

    [JsonProperty("description")]
    public string? Description { get; set; }

    [JsonProperty("banner")]
    public string? Banner { get; set; }

    [JsonProperty("premium_tier")]
    public int PremiumTier { get; set; }

    [JsonProperty("premium_subscription_count")]
    public int? PremiumSubscriptionCount { get; set; }

    [JsonProperty("preferred_locale")]
    public required string PreferredLocale { get; set; }

    [JsonProperty("public_updates_channel_id")]
    public string? PublicUpdatesChannelId { get; set; }

    [JsonProperty("max_video_channel_users")]
    public int? MaxVideoChannelUsers { get; set; }

    [JsonProperty("max_stage_video_channel_users")]
    public int? MaxStageVideoChannelUsers { get; set; }

    [JsonProperty("approximate_member_count")]
    public int? ApproximateMemberCount { get; set; }

    [JsonProperty("approximate_presence_count")]
    public int? ApproximatePresenceCount { get; set; }

    [JsonProperty("welcome_screen")]
    public WelcomeScreen? WelcomeScreen { get; set; }

    [JsonProperty("nsfw_level")]
    public int? NsfwLevel { get; set; }

    [JsonProperty("stickers")]
    public Sticker[]? Stickers { get; set; }

    [JsonProperty("premium_progress_bar_enabled")]
    public bool? PremiumProgressBarEnabled { get; set; }

    [JsonProperty("safety_alerts_channel_id")]
    public string? SafetyAlertsChannelId { get; set; }

    [JsonIgnore]
    public Dictionary<string, Channel> Channels = new();

    [JsonIgnore]
    public Dictionary<string, GuildMember> Members = new();

    [JsonIgnore]
    public Dictionary<string, GuildRole> Roles = new();
}