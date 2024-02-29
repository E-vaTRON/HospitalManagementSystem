namespace HospitalManagementSystem.Domain;

public class EmployeeSchedule : EntityBase
{
    public DayOfWeek    WorkingDay              { get; set; }
    public TimeSpan     StartTime               { get; set; }
    public TimeSpan     EndTime                 { get; set; }
    public bool         IsFlexible              { get; set; } // cho phép thời gian linh động
    public int          SlotDurationInMinutes   { get; set; } // slot làm việc có khoản thời gian

    public string?  EmployeeId  { get; set; }
    public Employee Employee    { get; set; } = default!;
}
