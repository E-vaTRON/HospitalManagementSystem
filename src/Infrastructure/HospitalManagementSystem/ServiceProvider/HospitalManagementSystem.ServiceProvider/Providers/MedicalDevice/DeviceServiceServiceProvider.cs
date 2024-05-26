using CoreDeviceService = HospitalManagementSystem.Domain.DeviceService;
using DTODeviceServiceIn = HospitalManagementSystem.Application.InputDeviceServiceDTO;
using DTODeviceServiceOut = HospitalManagementSystem.Application.OutputDeviceServiceDTO;

namespace HospitalManagementSystem.ServiceProvider;

public class DeviceServiceServiceProvider : ServiceProviderBase<DTODeviceServiceOut, DTODeviceServiceIn, CoreDeviceService>, IDeviceServiceServiceProvider
{
    public DeviceServiceServiceProvider(IDeviceServiceDataProvider dataProvider, IMapper mapper) : base(dataProvider, mapper)
    {
    }
}