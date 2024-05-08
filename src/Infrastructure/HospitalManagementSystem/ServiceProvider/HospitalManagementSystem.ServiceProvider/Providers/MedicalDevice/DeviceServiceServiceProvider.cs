using CoreDeviceService = HospitalManagementSystem.Domain.DeviceService;

namespace HospitalManagementSystem.ServiceProvider;

public class DeviceServiceServiceProvider : ServiceProviderBase<CoreDeviceService>, IDeviceServiceServiceProvider
{
    public DeviceServiceServiceProvider(IDeviceServiceDataProvider dataProvider) : base(dataProvider)
    {
    }
}