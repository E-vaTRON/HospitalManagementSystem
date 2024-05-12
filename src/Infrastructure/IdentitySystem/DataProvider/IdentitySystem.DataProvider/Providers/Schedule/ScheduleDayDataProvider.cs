using CoreScheduleDay = IdentitySystem.Domain.ScheduleDay;
using DataScheduleDay = IdentitySystem.DataProvider.ScheduleDay;

namespace IdentitySystem.DataProvider;

public class ScheduleDayDataProvider : DataProviderBase<CoreScheduleDay, DataScheduleDay>, IScheduleDayDataProvider
{
    public ScheduleDayDataProvider(IdentitySystemDbContext context, IMapper mapper) : base(context, mapper)
    {
    }
}
