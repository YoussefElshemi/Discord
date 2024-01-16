using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Discord.Enums;

[JsonConverter(typeof(StringEnumConverter))]
public enum GuildFeatures
{
    [EnumMember(Value = "ANIMATED_BANNER")]
    AnimatedBanner,
    [EnumMember(Value = "ANIMATED_ICON")]
    AnimatedIcon,
    [EnumMember(Value = "APPLICATION_COMMAND_PERMISSIONS_V2")]
    ApplicationCommandPermissionsV2,
    [EnumMember(Value = "AUTO_MODERATION")]
    AutoModeration,
    [EnumMember(Value = "BANNER")]
    Banner,
    [EnumMember(Value = "COMMUNITY")]
    Community,
    [EnumMember(Value = "CREATOR_MONETIZABLE_PROVISIONAL")]
    CreatorMonetizableProvisional,
    [EnumMember(Value = "CREATOR_STORE_PAGE")]
    CreatorStorePage,
    [EnumMember(Value = "DEVELOPER_SUPPORT_SERVER")]
    DeveloperSupportServer,
    [EnumMember(Value = "DISCOVERABLE")]
    Discoverable,
    [EnumMember(Value = "FEATURABLE")]
    Featurable,
    [EnumMember(Value = "INVITES_DISABLED")]
    InvitesDisabled,
    [EnumMember(Value = "INVITE_SPLASH")]
    InviteSplash,
    [EnumMember(Value = "MEMBER_VERIFICATION_GATE_ENABLED")]
    MemberVerificationGateEnabled,
    [EnumMember(Value = "MORE_STICKERS")]
    MoreStickers,
    [EnumMember(Value = "NEWS")]
    News,
    [EnumMember(Value = "PARTNERED")]
    Partnered,
    [EnumMember(Value = "PREVIEW_ENABLED")]
    PreviewEnabled,
    [EnumMember(Value = "RAID_ALERTS_DISABLED")]
    RaidAlertsDisabled,
    [EnumMember(Value = "ROLE_ICONS")]
    RoleIcons,
    [EnumMember(Value = "ROLE_SUBSCRIPTIONS_AVAILABLE_FOR_PURCHASE")]
    RoleSubscriptionsAvailableForPurchase,
    [EnumMember(Value = "ROLE_SUBSCRIPTIONS_ENABLED")]
    RoleSubscriptionsEnabled,
    [EnumMember(Value = "TICKETED_EVENTS_ENABLED")]
    TicketedEventsEnabled,
    [EnumMember(Value = "VANITY_URL")]
    VanityUrl,
    [EnumMember(Value = "VERIFIED")]
    Verified,
    [EnumMember(Value = "VIP_REGIONS")]
    VipRegions,
    [EnumMember(Value = "WELCOME_SCREEN_ENABLED")]
    WelcomeScreenEnabled
}