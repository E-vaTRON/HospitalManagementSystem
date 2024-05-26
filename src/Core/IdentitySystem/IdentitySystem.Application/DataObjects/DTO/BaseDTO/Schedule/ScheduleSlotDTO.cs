namespace IdentitySystem.Application;

public record ScheduleSlotDTO : DTOBase
{
    public int      StartTime   { get; init; }
    public int      EndTime     { get; init; }
    public string?  Task        { get; init; }
}
