using CoreRoom = HospitalManagementSystem.Domain.Room;
using DataRoom = HospitalManagementSystem.DataProvider.Room;

namespace HospitalManagementSystem.DataProvider;

public class RoomDataProvider<TDbContext> : DataProviderBase<TDbContext, CoreRoom, DataRoom>, IRoomDataProvider
    where TDbContext : DbContext
{
    public RoomDataProvider(TDbContext context, IMapper mapper) : base(context, mapper)
    {
    }
}
