using CoreScheduleDay = IdentitySystem.Domain.ScheduleDay;
using DTOScheduleDayIn = IdentitySystem.Application.InputScheduleDayDTO;
using DTOScheduleDayOut = IdentitySystem.Application.OutputScheduleDayDTO;

namespace IdentitySystem.ServiceProvider;

public class ScheduleDayServiceProvider : ServiceProviderBase<DTOScheduleDayOut, DTOScheduleDayIn, CoreScheduleDay>, IScheduleDayServiceProvider
{
    public ScheduleDayServiceProvider(IScheduleDayDataProvider dataProvider, IMapper mapper) : base(dataProvider, mapper)
    {
    }
}
