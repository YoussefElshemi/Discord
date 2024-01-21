using Discord.Models.EventArgs;

namespace Discord.Models;

public class EventEmitter
{
    public event EventHandler? OnReady;
    public event EventHandler<GuildApplicationCommandPermissionsUpdateEventArgs>? OnApplicationCommandPermissionsUpdate;
    public event EventHandler? OnAutoModerationRuleCreate;
    public event EventHandler? OnAutoModerationRuleUpdate;
    public event EventHandler? OnAutoModerationRuleDelete;
    public event EventHandler? OnAutoModerationActionExecution;
    public event EventHandler? OnChannelCreate;
    public event EventHandler? OnChannelUpdate;
    public event EventHandler? OnChannelDelete;
    public event EventHandler? OnChannelPinsUpdate;
    public event EventHandler? OnThreadCreate;
    public event EventHandler? OnThreadUpdate;
    public event EventHandler? OnThreadDelete;
    public event EventHandler? OnThreadListSync;
    public event EventHandler? OnThreadMemberUpdate;
    public event EventHandler? OnThreadMembersUpdate;
    public event EventHandler? OnEntitlementCreate;
    public event EventHandler? OnEntitlementUpdate;
    public event EventHandler? OnEntitlementDelete;
    public event EventHandler? OnGuildCreate;
    public event EventHandler? OnGuildUpdate;
    public event EventHandler? OnGuildDelete;

    protected void ReadyEvent(System.EventArgs e)
    {
        OnReady?.Invoke(this, e);
    }

    protected void ApplicationCommandPermissionsUpdateEvent(GuildApplicationCommandPermissionsUpdateEventArgs e)
    {
        OnApplicationCommandPermissionsUpdate?.Invoke(this, e);
    }

    protected void AutoModerationRuleCreateEvent(AutoModerationRuleEventArgs e)
    {
        OnAutoModerationRuleCreate?.Invoke(this, e);
    }

    protected void AutoModerationRuleUpdateEvent(AutoModerationRuleEventArgs e)
    {
        OnAutoModerationRuleUpdate?.Invoke(this, e);
    }

    protected void AutoModerationRuleDeleteEvent(AutoModerationRuleEventArgs e)
    {
        OnAutoModerationRuleDelete?.Invoke(this, e);
    }

    protected void AutoModerationActionExecutionEvent(AutoModerationActionExecutionEventArgs e)
    {
        OnAutoModerationActionExecution?.Invoke(this, e);
    }

    protected void ChannelCreateEvent(ChannelEventArgs e)
    {
        OnChannelCreate?.Invoke(this, e);
    }

    protected void ChannelUpdateEvent(ChannelEventArgs e)
    {
        OnChannelUpdate?.Invoke(this, e);
    }

    protected void ChannelDeleteEvent(ChannelEventArgs e)
    {
        OnChannelDelete?.Invoke(this, e);
    }

    protected void ChannelPinsUpdateEvent(ChannelPinsUpdateEventArgs e)
    {
        OnChannelPinsUpdate?.Invoke(this, e);
    }

    protected void ThreadCreateEvent(ThreadEventArgs e)
    {
        OnThreadCreate?.Invoke(this, e);
    }

    protected void ThreadUpdateEvent(ThreadEventArgs e)
    {
        OnThreadUpdate?.Invoke(this, e);
    }

    protected void ThreadDeleteEvent(ThreadEventArgs e)
    {
        OnThreadDelete?.Invoke(this, e);
    }

    protected void ThreadListSyncEvent(ThreadListSyncEventArgs e)
    {
        OnThreadListSync?.Invoke(this, e);
    }

    protected void ThreadMemberUpdateEvent(ThreadMemberUpdateEventArgs e)
    {
        OnThreadMemberUpdate?.Invoke(this, e);
    }

    protected void ThreadMembersUpdateEvent(ThreadMembersUpdateEventArgs e)
    {
        OnThreadMembersUpdate?.Invoke(this, e);
    }

    protected void EntitlementCreateEvent(EntitlementEventArgs e)
    {
        OnEntitlementCreate?.Invoke(this, e);
    }

    protected void EntitlementUpdateEvent(EntitlementEventArgs e)
    {
        OnEntitlementUpdate?.Invoke(this, e);
    }

    protected void EntitlementDeleteEvent(EntitlementEventArgs e)
    {
        OnEntitlementDelete?.Invoke(this, e);
    }

    protected void GuildCreateEvent(GuildCreateEventArgs e)
    {
        OnGuildCreate?.Invoke(this, e);
    }

    protected void GuildUpdateEvent(GuildEventArgs e)
    {
        OnGuildUpdate?.Invoke(this, e);
    }

    protected void GuildDeleteEvent(GuildEventArgs e)
    {
        OnGuildDelete?.Invoke(this, e);
    }
}