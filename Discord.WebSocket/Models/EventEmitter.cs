using Discord.Models.DispatchEvents;

namespace Discord.Models;

public class EventEmitter
{
    public event EventHandler? OnReady;
    public event EventHandler<ClientEventArgs<GuildApplicationCommandPermissionsUpdateEvent>>? OnApplicationCommandPermissionsUpdate;
    public event EventHandler<ClientEventArgs<AutoModerationRuleEvent>>? OnAutoModerationRuleCreate;
    public event EventHandler<ClientEventArgs<AutoModerationRuleEvent>>? OnAutoModerationRuleUpdate;
    public event EventHandler<ClientEventArgs<AutoModerationRuleEvent>>? OnAutoModerationRuleDelete;
    public event EventHandler<ClientEventArgs<AutoModerationActionExecutionEvent>>? OnAutoModerationActionExecution;
    public event EventHandler<ClientEventArgs<ChannelEvent>>? OnChannelCreate;
    public event EventHandler<ClientEventArgs<ChannelEvent>>? OnChannelUpdate;
    public event EventHandler<ClientEventArgs<ChannelEvent>>? OnChannelDelete;
    public event EventHandler<ClientEventArgs<ChannelPinsUpdateEvent>>? OnChannelPinsUpdate;
    public event EventHandler<ClientEventArgs<ThreadEvent>>? OnThreadCreate;
    public event EventHandler<ClientEventArgs<ThreadEvent>>? OnThreadUpdate;
    public event EventHandler<ClientEventArgs<ThreadEvent>>? OnThreadDelete;
    public event EventHandler<ClientEventArgs<ThreadListSyncEvent>>? OnThreadListSync;
    public event EventHandler<ClientEventArgs<ThreadMemberUpdateEvent>>? OnThreadMemberUpdate;
    public event EventHandler<ClientEventArgs<ThreadMembersUpdateEvent>>? OnThreadMembersUpdate;
    public event EventHandler<ClientEventArgs<EntitlementEvent>>? OnEntitlementCreate;
    public event EventHandler<ClientEventArgs<EntitlementEvent>>? OnEntitlementUpdate;
    public event EventHandler<ClientEventArgs<EntitlementEvent>>? OnEntitlementDelete;
    public event EventHandler<ClientEventArgs<GuildCreateEvent>>? OnGuildCreate;
    public event EventHandler<ClientEventArgs<GuildEvent>>? OnGuildUpdate;
    public event EventHandler<ClientEventArgs<GuildEvent>>? OnGuildDelete;

    protected void ReadyEvent(EventArgs e)
    {
        OnReady?.Invoke(this, e);
    }

    protected void ApplicationCommandPermissionsUpdateEvent(ClientEventArgs<GuildApplicationCommandPermissionsUpdateEvent> e)
    {
        OnApplicationCommandPermissionsUpdate?.Invoke(this, e);
    }

    protected void AutoModerationRuleCreateEvent(ClientEventArgs<AutoModerationRuleEvent> e)
    {
        OnAutoModerationRuleCreate?.Invoke(this, e);
    }

    protected void AutoModerationRuleUpdateEvent(ClientEventArgs<AutoModerationRuleEvent> e)
    {
        OnAutoModerationRuleUpdate?.Invoke(this, e);
    }

    protected void AutoModerationRuleDeleteEvent(ClientEventArgs<AutoModerationRuleEvent> e)
    {
        OnAutoModerationRuleDelete?.Invoke(this, e);
    }

    protected void AutoModerationActionExecutionEvent(ClientEventArgs<AutoModerationActionExecutionEvent> e)
    {
        OnAutoModerationActionExecution?.Invoke(this, e);
    }

    protected void ChannelCreateEvent(ClientEventArgs<ChannelEvent> e)
    {
        OnChannelCreate?.Invoke(this, e);
    }

    protected void ChannelUpdateEvent(ClientEventArgs<ChannelEvent> e)
    {
        OnChannelUpdate?.Invoke(this, e);
    }

    protected void ChannelDeleteEvent(ClientEventArgs<ChannelEvent> e)
    {
        OnChannelDelete?.Invoke(this, e);
    }

    protected void ChannelPinsUpdateEvent(ClientEventArgs<ChannelPinsUpdateEvent> e)
    {
        OnChannelPinsUpdate?.Invoke(this, e);
    }

    protected void ThreadCreateEvent(ClientEventArgs<ThreadEvent> e)
    {
        OnThreadCreate?.Invoke(this, e);
    }

    protected void ThreadUpdateEvent(ClientEventArgs<ThreadEvent> e)
    {
        OnThreadUpdate?.Invoke(this, e);
    }

    protected void ThreadDeleteEvent(ClientEventArgs<ThreadEvent> e)
    {
        OnThreadDelete?.Invoke(this, e);
    }

    protected void ThreadListSyncEvent(ClientEventArgs<ThreadListSyncEvent> e)
    {
        OnThreadListSync?.Invoke(this, e);
    }

    protected void ThreadMemberUpdateEvent(ClientEventArgs<ThreadMemberUpdateEvent> e)
    {
        OnThreadMemberUpdate?.Invoke(this, e);
    }

    protected void ThreadMembersUpdateEvent(ClientEventArgs<ThreadMembersUpdateEvent> e)
    {
        OnThreadMembersUpdate?.Invoke(this, e);
    }

    protected void EntitlementCreateEvent(ClientEventArgs<EntitlementEvent> e)
    {
        OnEntitlementCreate?.Invoke(this, e);
    }

    protected void EntitlementUpdateEvent(ClientEventArgs<EntitlementEvent> e)
    {
        OnEntitlementUpdate?.Invoke(this, e);
    }

    protected void EntitlementDeleteEvent(ClientEventArgs<EntitlementEvent> e)
    {
        OnEntitlementDelete?.Invoke(this, e);
    }

    protected void GuildCreateEvent(ClientEventArgs<GuildCreateEvent> e)
    {
        OnGuildCreate?.Invoke(this, e);
    }

    protected void GuildUpdateEvent(ClientEventArgs<GuildEvent> e)
    {
        OnGuildUpdate?.Invoke(this, e);
    }

    protected void GuildDeleteEvent(ClientEventArgs<GuildEvent> e)
    {
        OnGuildDelete?.Invoke(this, e);
    }
}