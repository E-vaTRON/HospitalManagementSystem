using DTODeviceServiceIn = HospitalManagementSystem.Application.InputDeviceServiceDTO;
using DTODeviceServiceOut = HospitalManagementSystem.Application.OutputDeviceServiceDTO;

namespace HospitalManagementSystem.REST;

public class DeviceServiceController : BaseHMSController<DTODeviceServiceOut, DTODeviceServiceIn>
{
    public DeviceServiceController(IDeviceServiceServiceProvider serviceProvider) : base(serviceProvider)
    {
    }
}