using CoreDeviceService = HospitalManagementSystem.Domain.DeviceService;
using DTODeviceService = HospitalManagementSystem.Application.DeviceServiceDTO;

namespace HospitalManagementSystem.ServiceProvider;

public class DeviceServiceServiceProvider : ServiceProviderBase<DTODeviceService, CoreDeviceService>, IDeviceServiceServiceProvider
{
    public DeviceServiceServiceProvider(IDeviceServiceDataProvider dataProvider, IMapper mapper) : base(dataProvider, mapper)
    {
    }
}