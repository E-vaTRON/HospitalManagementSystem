using CoreRoomAssignment = HospitalManagementSystem.Domain.RoomAssignment;
using DataRoomAssignment = HospitalManagementSystem.DataProvider.RoomAssignment;

namespace HospitalManagementSystem.DataProvider;

public class RoomAssignmentDataProvider : DataProviderBase<CoreRoomAssignment, DataRoomAssignment>, IRoomAssignmentServiceProvider
{
    public RoomAssignmentDataProvider(HospitalManagementSystemDbContext context, IMapper mapper) : base(context, mapper)
    {
    }
}