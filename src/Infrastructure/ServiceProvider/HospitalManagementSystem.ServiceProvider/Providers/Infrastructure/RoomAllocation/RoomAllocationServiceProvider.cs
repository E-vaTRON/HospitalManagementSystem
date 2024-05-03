using CoreRoomAllocation = HospitalManagementSystem.Domain.RoomAllocation;

namespace HospitalManagementSystem.ServiceProvider;

public class RoomAllocationServiceProvider : ServiceProviderBase<CoreRoomAllocation>, IRoomAllocationServiceProvider
{
    public RoomAllocationServiceProvider(RoomAllocationDataProvider dataProvider) : base(dataProvider)
    {
    }
}
