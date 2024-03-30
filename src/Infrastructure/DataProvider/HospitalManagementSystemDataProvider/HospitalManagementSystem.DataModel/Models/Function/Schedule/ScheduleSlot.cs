namespace HospitalManagementSystem.DataProvider;

public class ScheduleSlot : ModelBase
{
    public int      StartTime   { get; set; }
    public int      EndTime     { get; set; }
    public string?  Task        { get; set; }

    public string?      ScheduleDayId   { get; set; }
    public ScheduleDay  ScheduleDay     { get; set; } = default!;
}
