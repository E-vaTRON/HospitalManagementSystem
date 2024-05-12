using CoreRoomAssignment = HospitalManagementSystem.Domain.RoomAssignment;
using DTORoomAssignment = HospitalManagementSystem.Application.RoomAssignmentDTO;

namespace HospitalManagementSystem.ServiceProvider;

public class RoomAssignmentServiceProvider : ServiceProviderBase<DTORoomAssignment, CoreRoomAssignment>, IRoomAssignmentServiceProvider
{
    public RoomAssignmentServiceProvider(IRoomAssignmentDataProvider dataProvider, IMapper mapper) : base(dataProvider, mapper)
    {
    }
}
