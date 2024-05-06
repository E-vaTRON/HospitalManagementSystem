using CoreDeviceInventory = HospitalManagementSystem.Domain.DeviceInventory;

namespace HospitalManagementSystem.ServiceProvider;

public class DeviceInventoryServiceProvider : ServiceProviderBase<CoreDeviceInventory>, IDeviceInventoryServiceProvider
{
    public DeviceInventoryServiceProvider(IDeviceInventoryDataProvider dataProvider) : base(dataProvider)
    {
    }
}
