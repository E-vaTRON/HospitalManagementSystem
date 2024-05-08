namespace IdentitySystem.Domain;

public class ScheduleSlot : EntityBase
{
    public int      StartTime   { get; set; }
    public int      EndTime     { get; set; }
    public string?  Task        { get; set; }
}
