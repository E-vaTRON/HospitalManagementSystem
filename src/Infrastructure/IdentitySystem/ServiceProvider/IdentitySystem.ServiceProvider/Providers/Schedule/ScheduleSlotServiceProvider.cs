using CoreScheduleSlot = IdentitySystem.Domain.ScheduleSlot;
using DTOScheduleSlot = IdentitySystem.Application.ScheduleSlotDTO;

namespace IdentitySystem.ServiceProvider;

public class ScheduleSlotServiceProvider : ServiceProviderBase<DTOScheduleSlot, CoreScheduleSlot>, IScheduleSlotServiceProvider
{
    public ScheduleSlotServiceProvider(IScheduleSlotDataProvider dataProvider, IMapper mapper) : base(dataProvider, mapper)
    {
    }
}
