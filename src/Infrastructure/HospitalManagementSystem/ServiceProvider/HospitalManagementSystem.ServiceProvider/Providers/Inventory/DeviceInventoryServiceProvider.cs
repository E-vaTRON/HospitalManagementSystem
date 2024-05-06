using CoreDeviceInventory = HospitalManagementSystem.Domain.DeviceInventory;

namespace HospitalManagementSystem.ServiceProvider;

public class DeviceInventoryServiceProvider : ServiceProviderBase<CoreDeviceInventory>, IDeviceInventoryServiceProvider
{
    public DeviceInventoryServiceProvider(DeviceInventoryDataProvider dataProvider) : base(dataProvider)
    {
    }
}
