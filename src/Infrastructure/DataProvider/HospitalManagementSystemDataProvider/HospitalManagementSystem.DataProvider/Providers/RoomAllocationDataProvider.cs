using CoreRoomAllocation = HospitalManagementSystem.Domain.RoomAllocation;
using DataRoomAllocation = HospitalManagementSystem.DataProvider.RoomAllocation;

namespace HospitalManagementSystem.DataProvider;

public class RoomAllocationDataProvider<TDbContext> : DataProviderBase<TDbContext, CoreRoomAllocation, DataRoomAllocation>, IRoomAllocationDataProvider
    where TDbContext : DbContext
{
    public RoomAllocationDataProvider(TDbContext context, IMapper mapper) : base(context, mapper)
    {
    }
}
