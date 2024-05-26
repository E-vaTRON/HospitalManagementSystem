namespace IdentitySystem.Application;

public record ScheduleDayDTO : DTOBase
{
    public DayOfWeek    WorkingDay  { get; init; }
    public bool         IsFlexible  { get; init; }
}
