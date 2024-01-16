using System.Runtime.Serialization;

namespace Discord.Enums;

public enum GuildScheduledEventStatus
{
    SCHEDULED = 1,
    ACTIVE = 2,
    COMPLETED = 3,
    CANCELED = 4
}