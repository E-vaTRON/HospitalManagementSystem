namespace IdentitySystem.Domain;

public static class ScheduleSlotExtensions
{
    #region [ Public Method ]
    public static ScheduleSlot RemoveRelated(this ScheduleSlot scheduleSlot)
    {
        scheduleSlot.ScheduleDay = null!;
        return scheduleSlot;
    }
    #endregion
}
