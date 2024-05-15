namespace IdentitySystem.Domain;

public static class ScheduleDayFactory
{
    public static ScheduleDay Create()
    {
        return new ScheduleDay();
    }

    public static ScheduleDay Create(DayOfWeek workingDay, bool isFlexible, string userId)
    {
        return new ScheduleDay()
        {
            WorkingDay = workingDay,
            IsFlexible = isFlexible,
            UserId = userId
        };
    }
}
