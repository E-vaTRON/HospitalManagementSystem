namespace IdentitySystem.Domain;

public static class ScheduleDayFactory
{
    public static ScheduleDay Create()
    {
        return new ScheduleDay();
    }

    public static ScheduleDay Create(DateTime workingDay, bool isFlexible, string userId)
    {
        return new ScheduleDay()
        {
            WorkingDay = workingDay,
            IsFlexible = isFlexible,
            UserId = userId
        };
    }
}
