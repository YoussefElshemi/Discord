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

    protected void EmitReadyEvent(EventArgs e)
    {
        OnReady?.Invoke(this, e);
    }

    protected void EmitApplicationCommandPermissionsUpdateEvent(ClientEventArgs<GuildApplicationCommandPermissionsUpdateEvent> e)
    {
        OnApplicationCommandPermissionsUpdate?.Invoke(this, e);
    }

    protected void EmitAutoModerationRuleCreateEvent(ClientEventArgs<AutoModerationRuleEvent> e)
    {
        OnAutoModerationRuleCreate?.Invoke(this, e);
    }

    protected void EmitAutoModerationRuleUpdateEvent(ClientEventArgs<AutoModerationRuleEvent> e)
    {
        OnAutoModerationRuleUpdate?.Invoke(this, e);
    }

    protected void EmitAutoModerationRuleDeleteEvent(ClientEventArgs<AutoModerationRuleEvent> e)
    {
        OnAutoModerationRuleDelete?.Invoke(this, e);
    }

    protected void EmitAutoModerationActionExecutionEvent(ClientEventArgs<AutoModerationActionExecutionEvent> e)
    {
        OnAutoModerationActionExecution?.Invoke(this, e);
    }

    protected void EmitChannelCreateEvent(ClientEventArgs<ChannelEvent> e)
    {
        OnChannelCreate?.Invoke(this, e);
    }

    protected void EmitChannelUpdateEvent(ClientEventArgs<ChannelEvent> e)
    {
        OnChannelUpdate?.Invoke(this, e);
    }

    protected void EmitChannelDeleteEvent(ClientEventArgs<ChannelEvent> e)
    {
        OnChannelDelete?.Invoke(this, e);
    }

    protected void EmitChannelPinsUpdateEvent(ClientEventArgs<ChannelPinsUpdateEvent> e)
    {
        OnChannelPinsUpdate?.Invoke(this, e);
    }

    protected void EmitThreadCreateEvent(ClientEventArgs<ThreadEvent> e)
    {
        OnThreadCreate?.Invoke(this, e);
    }

    protected void EmitThreadUpdateEvent(ClientEventArgs<ThreadEvent> e)
    {
        OnThreadUpdate?.Invoke(this, e);
    }

    protected void EmitThreadDeleteEvent(ClientEventArgs<ThreadEvent> e)
    {
        OnThreadDelete?.Invoke(this, e);
    }

    protected void EmitThreadListSyncEvent(ClientEventArgs<ThreadListSyncEvent> e)
    {
        OnThreadListSync?.Invoke(this, e);
    }

    protected void EmitThreadMemberUpdateEvent(ClientEventArgs<ThreadMemberUpdateEvent> e)
    {
        OnThreadMemberUpdate?.Invoke(this, e);
    }

    protected void EmitThreadMembersUpdateEvent(ClientEventArgs<ThreadMembersUpdateEvent> e)
    {
        OnThreadMembersUpdate?.Invoke(this, e);
    }

    protected void EmitEntitlementCreateEvent(ClientEventArgs<EntitlementEvent> e)
    {
        OnEntitlementCreate?.Invoke(this, e);
    }

    protected void EmitEntitlementUpdateEvent(ClientEventArgs<EntitlementEvent> e)
    {
        OnEntitlementUpdate?.Invoke(this, e);
    }

    protected void EmitEntitlementDeleteEvent(ClientEventArgs<EntitlementEvent> e)
    {
        OnEntitlementDelete?.Invoke(this, e);
    }

    protected void EmitGuildCreateEvent(ClientEventArgs<GuildCreateEvent> e)
    {
        OnGuildCreate?.Invoke(this, e);
    }

    protected void EmitGuildUpdateEvent(ClientEventArgs<GuildEvent> e)
    {
        OnGuildUpdate?.Invoke(this, e);
    }

    protected void EmitGuildDeleteEvent(ClientEventArgs<GuildEvent> e)
    {
        OnGuildDelete?.Invoke(this, e);
    }
}