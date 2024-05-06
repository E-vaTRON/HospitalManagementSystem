using CoreDeviceService = HospitalManagementSystem.Domain.DeviceService;

namespace HospitalManagementSystem.ServiceProvider;

public class DeviceServiceServiceProvider : ServiceProviderBase<CoreDeviceService>, IDeviceServiceServiceProvider
{
    public DeviceServiceServiceProvider(DeviceServiceDataProvider dataProvider) : base(dataProvider)
    {
    }
}