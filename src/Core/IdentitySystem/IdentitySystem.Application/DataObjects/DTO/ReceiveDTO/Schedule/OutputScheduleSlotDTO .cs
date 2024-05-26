namespace IdentitySystem.Application;

public record OutputScheduleSlotDTO : ScheduleSlotDTO
{
    public ScheduleDayDTO? ScheduleDayDTO { get; init; }
}