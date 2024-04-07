using CoreRoomAssignment = HospitalManagementSystem.Domain.RoomAssignment;
using DataRoomAssignment = HospitalManagementSystem.DataProvider.RoomAssignment;

namespace HospitalManagementSystem.DataProvider;

public class RoomAssignmentDataProvider<TDbContext> : DataProviderBase<TDbContext, CoreRoomAssignment, DataRoomAssignment>, IRoomAssignmentDataProvider
    where TDbContext : DbContext
{
    public RoomAssignmentDataProvider(TDbContext context, IMapper mapper) : base(context, mapper)
    {
    }
}