using CoreRoom = HospitalManagementSystem.Domain.Room;

namespace HospitalManagementSystem.ServiceProvider;

public class RoomServiceProvider : ServiceProviderBase<CoreRoom>, IRoomServiceProvider
{
    public RoomServiceProvider(RoomDataProvider dataProvider) : base(dataProvider)
    {
    }
}
