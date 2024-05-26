using CoreScheduleSlot = IdentitySystem.Domain.ScheduleSlot;
using DTOScheduleSlotIn = IdentitySystem.Application.InputScheduleSlotDTO;
using DTOScheduleSlotOut = IdentitySystem.Application.OutputScheduleSlotDTO;

namespace IdentitySystem.ServiceProvider;

public class ScheduleSlotServiceProvider : ServiceProviderBase<DTOScheduleSlotOut, DTOScheduleSlotIn, CoreScheduleSlot>, IScheduleSlotServiceProvider
{
    public ScheduleSlotServiceProvider(IScheduleSlotDataProvider dataProvider, IMapper mapper) : base(dataProvider, mapper)
    {
    }
}
