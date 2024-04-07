using CoreDeviceInventory = HospitalManagementSystem.Domain.DeviceInventory;
using DataDeviceInventory = HospitalManagementSystem.DataProvider.DeviceInventory;

namespace HospitalManagementSystem.DataProvider;

public class DeviceInventoryDataProvider<TDbContext> : DataProviderBase<TDbContext, CoreDeviceInventory, DataDeviceInventory>, IDeviceInventoryDataProvider
    where TDbContext : DbContext
{
    public DeviceInventoryDataProvider(TDbContext context, IMapper mapper) : base(context, mapper)
    {
    }
}
