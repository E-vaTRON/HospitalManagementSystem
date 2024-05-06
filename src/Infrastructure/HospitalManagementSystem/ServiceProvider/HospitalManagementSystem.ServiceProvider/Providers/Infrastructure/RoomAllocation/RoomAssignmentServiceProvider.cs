using CoreRoomAssignment = HospitalManagementSystem.Domain.RoomAssignment;

namespace HospitalManagementSystem.ServiceProvider;

public class RoomAssignmentServiceProvider : ServiceProviderBase<CoreRoomAssignment>, IRoomAssignmentServiceProvider
{
    public RoomAssignmentServiceProvider(RoomAssignmentDataProvider dataProvider) : base(dataProvider)
    {
    }
}
