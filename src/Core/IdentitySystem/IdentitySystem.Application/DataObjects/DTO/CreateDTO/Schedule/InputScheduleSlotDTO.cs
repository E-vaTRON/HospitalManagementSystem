namespace IdentitySystem.Application;

public record InputScheduleSlotDTO : ScheduleSlotDTO
{
    public string? ScheduleDayDTOId { get; init; }
}
