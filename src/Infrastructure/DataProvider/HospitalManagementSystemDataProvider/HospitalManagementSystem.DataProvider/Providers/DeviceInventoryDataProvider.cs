using CoreDeviceInventory = HospitalManagementSystem.Domain.DeviceInventory;
using DataDeviceInventory = HospitalManagementSystem.DataProvider.DeviceInventory;

namespace HospitalManagementSystem.DataProvider;

public class DeviceInventoryDataProvider : DataProviderBase<CoreDeviceInventory, DataDeviceInventory>, IDeviceInventoryDataProvider
{
    public DeviceInventoryDataProvider(HospitalManagementSystemDbContext context, IMapper mapper) : base(context, mapper)
    {
    }
}
