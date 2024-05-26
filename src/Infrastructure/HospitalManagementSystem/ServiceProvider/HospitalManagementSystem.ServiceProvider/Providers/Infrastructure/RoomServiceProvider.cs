using CoreRoom = HospitalManagementSystem.Domain.Room;
using DTORoomIn = HospitalManagementSystem.Application.InputRoomDTO;
using DTORoomOut = HospitalManagementSystem.Application.OutputRoomDTO;

namespace HospitalManagementSystem.ServiceProvider;

public class RoomServiceProvider : ServiceProviderBase<DTORoomOut, DTORoomIn, CoreRoom>, IRoomServiceProvider
{
    public RoomServiceProvider(IRoomDataProvider dataProvider, IMapper mapper) : base(dataProvider, mapper)
    {
    }
}
