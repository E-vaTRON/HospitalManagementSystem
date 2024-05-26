namespace IdentitySystem.Application;

public record OutputScheduleDayDTO : ScheduleDayDTO
{
    public UserDTO? UserDTO { get; init; }

    public ICollection<ScheduleSlotDTO>? ScheduleSlotDTOs { get; init; }
}
