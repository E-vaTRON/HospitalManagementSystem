using CoreScheduleDay = IdentitySystem.Domain.ScheduleDay;
using DTOScheduleDay = IdentitySystem.Application.ScheduleDayDTO;

namespace IdentitySystem.ServiceProvider;

public class ScheduleDayServiceProvider : ServiceProviderBase<DTOScheduleDay, CoreScheduleDay>, IScheduleDayServiceProvider
{
    public ScheduleDayServiceProvider(IScheduleDayDataProvider dataProvider, IMapper mapper) : base(dataProvider, mapper)
    {
    }
}
