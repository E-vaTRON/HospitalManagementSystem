namespace IdentitySystem.Domain;

public static class ScheduleDayExtensions
{
    #region [ Private Methods ]
    private static ScheduleDay AddUserRole(this ScheduleDay scheduleDay, ScheduleSlot scheduleSlot)
    {
        ArgumentException.ThrowIfNullOrEmpty(nameof(scheduleSlot));

        if (scheduleDay.ScheduleSlots.Any(x => x.Id == scheduleSlot.Id))
        {
            return scheduleDay;
        }

        scheduleSlot.ScheduleDayId = scheduleDay.Id;
        scheduleSlot.ScheduleDay = scheduleDay;
        scheduleDay.ScheduleSlots.Add(scheduleSlot);
        return scheduleDay;
    }
    #endregion

    #region [ Public Methods ]
    public static ScheduleDay AddUserRole(this ScheduleDay role)
    {
        return role.AddUserRole(ScheduleSlotFactory.Create());
    }

    public static ScheduleDay AddUserRole(this ScheduleDay role, int startTime, int endTime, string task)
    {
        return role.AddUserRole(ScheduleSlotFactory.Create(startTime, endTime, task));
    }

    public static ScheduleDay RemoveRelated(this ScheduleDay scheduleDay)
    {
        scheduleDay.User = null!;
        scheduleDay.ScheduleSlots.Clear();
        return scheduleDay;
    }
    #endregion
}
