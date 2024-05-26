using DTORoomIn = HospitalManagementSystem.Application.InputRoomDTO;
using DTORoomOut = HospitalManagementSystem.Application.OutputRoomDTO;

namespace HospitalManagementSystem.REST;

public class RoomController : BaseHMSController<DTORoomOut, DTORoomIn>
{
    public RoomController(IRoomServiceProvider serviceProvider) : base(serviceProvider)
    {
    }
}