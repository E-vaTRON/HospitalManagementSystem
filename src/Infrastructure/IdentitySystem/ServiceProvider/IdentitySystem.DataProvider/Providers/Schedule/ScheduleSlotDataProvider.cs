using CoreScheduleSlot = IdentitySystem.Domain.ScheduleSlot;
using DataScheduleSlot = IdentitySystem.DataProvider.ScheduleSlot;

namespace IdentitySystem.DataProvider;

public class ScheduleSlotDataProvider : DataProviderBase<CoreScheduleSlot, DataScheduleSlot>, IScheduleSlotDataProvider
{
    public ScheduleSlotDataProvider(IdentitySystemDbContext context, IMapper mapper) : base(context, mapper)
    {
    }
}
