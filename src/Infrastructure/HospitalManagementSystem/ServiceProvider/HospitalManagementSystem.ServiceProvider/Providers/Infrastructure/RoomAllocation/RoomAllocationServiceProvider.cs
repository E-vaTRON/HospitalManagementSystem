using CoreRoomAllocation = HospitalManagementSystem.Domain.RoomAllocation;
using DTORoomAllocationIn = HospitalManagementSystem.Application.InputRoomAllocationDTO;
using DTORoomAllocationOut = HospitalManagementSystem.Application.OutputRoomAllocationDTO;

namespace HospitalManagementSystem.ServiceProvider;

public class RoomAllocationServiceProvider : ServiceProviderBase<DTORoomAllocationOut, DTORoomAllocationIn, CoreRoomAllocation>, IRoomAllocationServiceProvider
{
    public RoomAllocationServiceProvider(IRoomAllocationDataProvider dataProvider, IMapper mapper) : base(dataProvider, mapper)
    {
    }
}
