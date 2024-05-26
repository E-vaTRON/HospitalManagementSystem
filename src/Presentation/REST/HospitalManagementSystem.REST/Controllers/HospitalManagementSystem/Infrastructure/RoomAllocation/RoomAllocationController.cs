using DTORoomAllocationIn = HospitalManagementSystem.Application.InputRoomAllocationDTO;
using DTORoomAllocationOut = HospitalManagementSystem.Application.OutputRoomAllocationDTO;

namespace HospitalManagementSystem.REST;

public class RoomAllocationController : BaseHMSController<DTORoomAllocationOut, DTORoomAllocationIn>
{
    public RoomAllocationController(IRoomAllocationServiceProvider serviceProvider) : base(serviceProvider)
    {
    }
}