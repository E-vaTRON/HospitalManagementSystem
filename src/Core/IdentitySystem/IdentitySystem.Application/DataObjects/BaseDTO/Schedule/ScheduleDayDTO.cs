namespace IdentitySystem.Application;

public class ScheduleDayDTO : DTOBase
{
    public DayOfWeek    WorkingDay  { get; set; }
    public bool         IsFlexible  { get; set; }

    public UserDTO?     UserDTO { get; set; }

    public ICollection<ScheduleSlotDTO> ScheduleSlotDTOs { get; set; } = new HashSet<ScheduleSlotDTO>();

}
