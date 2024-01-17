namespace Discord.Constants;

public static class Event
{
    public const string Ready = "READY";

    public const string GuildCreate = "GUILD_CREATE";

    public const string ApplicationCommandPermissionsUpdate = "APPLICATION_COMMAND_PERMISSIONS_UPDATE";

    public const string AutoModerationRuleCreate = "AUTO_MODERATION_RULE_CREATE";
    public const string AutoModerationRuleUpdate = "AUTO_MODERATION_RULE_UPDATE";
    public const string AutoModerationRuleDelete = "AUTO_MODERATION_RULE_DELETE";
    public const string AutoModerationActionExecution = "AUTO_MODERATION_ACTION_EXECUTION";

    public const string ChannelCreate = "CHANNEL_CREATE";
    public const string ChannelUpdate = "CHANNEL_UPDATE";
    public const string ChannelDelete = "CHANNEL_DELETE";

    public const string ThreadCreate = "THREAD_CREATE";
    public const string ThreadUpdate = "THREAD_UPDATE";
    public const string ThreadDelete = "THREAD_DELETE";

    public const string ThreadListSync = "THREAD_LIST_SYNC";
    public const string ThreadMemberUpdate = "THREAD_MEMBER_UPDATE";
    public const string ThreadMembersUpdate = "THREAD_MEMBERS_UPDATE";

}