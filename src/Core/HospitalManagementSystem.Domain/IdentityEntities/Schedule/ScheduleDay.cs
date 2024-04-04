namespace HospitalManagementSystem.Domain;

public class ScheduleDay : EntityBase
{
    public DayOfWeek    WorkingDay  { get; set; } // DateTime
    public bool         IsFlexible  { get; set; } // cho phép thời gian linh động

    public string?  UserId  { get; set; }
    public User     User    { get; set; } = default!;

    public ICollection<ScheduleSlot> ScheduleSlots {  get; set; } = new HashSet<ScheduleSlot>();
}
