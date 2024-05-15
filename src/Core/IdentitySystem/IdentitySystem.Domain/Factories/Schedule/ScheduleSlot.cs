﻿namespace IdentitySystem.Domain;

public static class ScheduleSlotFactory
{
    public static ScheduleSlot Create()
    {
        return new ScheduleSlot();
    }

    public static ScheduleSlot Create(int startTime, int endTime, string task, string scheduleDayId)
    {
        return new ScheduleSlot()
        {
            StartTime = startTime,
            EndTime = endTime,
            Task = task,
            ScheduleDayId = scheduleDayId
        };
    }

}
