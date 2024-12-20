﻿namespace IdentitySystem.DataProvider;

public class ScheduleSlot : ModelBase
{
    public int          StartTime   { get; set; }
    public int          EndTime     { get; set; }
    public string?      Task        { get; set; }

    public Guid?        ScheduleDayId   { get; set; }
    public ScheduleDay  ScheduleDay     { get; set; } = default!;
}
