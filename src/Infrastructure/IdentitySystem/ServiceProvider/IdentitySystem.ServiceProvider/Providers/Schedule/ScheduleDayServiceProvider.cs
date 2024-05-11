using CoreScheduleDay = IdentitySystem.Domain.ScheduleDay;
using DataScheduleDay = IdentitySystem.DataProvider.ScheduleDay;

namespace IdentitySystem.ServiceProvider;

public class ScheduleDayServiceProvider : ServiceProviderBase<CoreScheduleDay>, IScheduleDayServiceProvider
{
    public ScheduleDayServiceProvider(IScheduleDayDataProvider dataProvider) : base(dataProvider)
    {
    }
}
