﻿namespace IdentitySystem.DataProvider;

public class ScheduleDay : ModelBase
{
    public DayOfWeek    WorkingDay  { get; set; } // DateTime
    public bool         IsFlexible  { get; set; } // cho phép thời gian linh động

    public Guid?    UserId  { get; set; }
    public User     User    { get; set; } = default!;

    public ICollection<ScheduleSlot> ScheduleSlots {  get; set; } = new HashSet<ScheduleSlot>();
}
