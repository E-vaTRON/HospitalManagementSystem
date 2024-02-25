namespace HospitalManagementSystem.DataProvider;

public class EmployeeSchedule : ModelBase
{
    public string? EmployeeId { get; set; }
    public Employee Employee { get; set; } = default!;
    public DayOfWeek WorkingDay { get; set; }
    public TimeSpan StartTime { get; set; }
    public TimeSpan EndTime { get; set; }
}
