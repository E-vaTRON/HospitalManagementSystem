using CoreRoom = HospitalManagementSystem.Domain.Room;
using DTORoom = HospitalManagementSystem.Application.RoomDTO;

namespace HospitalManagementSystem.ServiceProvider;

public class RoomServiceProvider : ServiceProviderBase<DTORoom, CoreRoom>, IRoomServiceProvider
{
    public RoomServiceProvider(IRoomDataProvider dataProvider, IMapper mapper) : base(dataProvider, mapper)
    {
    }
}
