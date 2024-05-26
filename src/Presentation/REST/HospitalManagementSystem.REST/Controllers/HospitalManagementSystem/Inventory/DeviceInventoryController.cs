using DTODeviceInventoryIn = HospitalManagementSystem.Application.InputDeviceInventoryDTO;
using DTODeviceInventoryOut = HospitalManagementSystem.Application.OutputDeviceInventoryDTO;

namespace HospitalManagementSystem.REST;

public class DeviceInventoryController : BaseHMSController<DTODeviceInventoryOut, DTODeviceInventoryIn>
{
    public DeviceInventoryController(IDeviceInventoryServiceProvider serviceProvider) : base(serviceProvider)
    {
    }
}