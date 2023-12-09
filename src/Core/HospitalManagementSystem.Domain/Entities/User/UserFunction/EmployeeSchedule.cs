namespace HospitalManagementSystem.Domain.Entities.User.UserFunction;

public class EmployeeSchedule : EntityBase
{
    public string? EmployeeId { get; set; }
    public Employee Employee { get; set; } = default!;
    public DayOfWeek WorkingDay { get; set; }
    public TimeSpan StartTime { get; set; }
    public TimeSpan EndTime { get; set; }
}
