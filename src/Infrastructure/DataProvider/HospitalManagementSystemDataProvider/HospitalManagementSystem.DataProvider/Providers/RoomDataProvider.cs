using CoreRoom = HospitalManagementSystem.Domain.Room;
using DataRoom = HospitalManagementSystem.DataProvider.Room;

namespace HospitalManagementSystem.DataProvider
{
    public class RoomDataProvider : DataProviderBase<CoreRoom, DataRoom>, IRoomDataProvider
    {
        public RoomDataProvider(HospitalManagementSystemDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
