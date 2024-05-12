using CoreRoomAllocation = HospitalManagementSystem.Domain.RoomAllocation;
using DTORoomAllocation = HospitalManagementSystem.Application.RoomAllocationDTO;

namespace HospitalManagementSystem.ServiceProvider;

public class RoomAllocationServiceProvider : ServiceProviderBase<DTORoomAllocation, CoreRoomAllocation>, IRoomAllocationServiceProvider
{
    public RoomAllocationServiceProvider(IRoomAllocationDataProvider dataProvider, IMapper mapper) : base(dataProvider, mapper)
    {
    }
}
