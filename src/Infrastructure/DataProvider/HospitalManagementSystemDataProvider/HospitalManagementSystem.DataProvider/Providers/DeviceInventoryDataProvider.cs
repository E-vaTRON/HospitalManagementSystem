using CoreDeviceInventory = HospitalManagementSystem.Domain.DeviceInventory;
using DataDeviceInventory = HospitalManagementSystem.DataProvider.DeviceInventory;

namespace HospitalManagementSystem.DataProvider;

public class DeviceInventoryDataProvider : DataProviderBase<CoreDeviceInventory, DataDeviceInventory>, IDeviceInventoryServiceProvider
{
    public DeviceInventoryDataProvider(HospitalManagementSystemDbContext context, IMapper mapper) : base(context, mapper)
    {
    }
}
