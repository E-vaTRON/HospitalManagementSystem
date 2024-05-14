namespace IdentitySystem.Application;

public class ScheduleSlotDTO : DTOBase
{
    public int      StartTime   { get; set; }
    public int      EndTime     { get; set; }
    public string?  Task        { get; set; }

    public ScheduleDayDTO? ScheduleDay { get; set; }
}
