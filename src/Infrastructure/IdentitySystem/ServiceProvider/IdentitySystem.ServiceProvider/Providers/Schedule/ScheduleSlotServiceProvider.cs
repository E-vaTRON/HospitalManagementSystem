using CoreScheduleSlot = IdentitySystem.Domain.ScheduleSlot;
using DataScheduleSlot = IdentitySystem.DataProvider.ScheduleSlot;

namespace IdentitySystem.ServiceProvider;

public class ScheduleSlotServiceProvider : ServiceProviderBase<CoreScheduleSlot>, IScheduleSlotServiceProvider
{
    public ScheduleSlotServiceProvider(IScheduleSlotDataProvider dataProvider) : base(dataProvider)
    {
    }
}
