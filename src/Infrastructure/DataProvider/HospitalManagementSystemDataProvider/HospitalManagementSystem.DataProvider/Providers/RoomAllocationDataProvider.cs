using CoreRoomAllocation = HospitalManagementSystem.Domain.RoomAllocation;
using DataRoomAllocation = HospitalManagementSystem.DataProvider.RoomAllocation;

namespace HospitalManagementSystem.DataProvider
{
    public class RoomAllocationDataProvider : DataProviderBase<CoreRoomAllocation, DataRoomAllocation>, IRoomAllocationDataProvider
    {
        public RoomAllocationDataProvider(HospitalManagementSystemDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
