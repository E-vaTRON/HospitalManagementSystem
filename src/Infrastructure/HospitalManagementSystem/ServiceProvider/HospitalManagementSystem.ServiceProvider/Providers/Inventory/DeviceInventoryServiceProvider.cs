using CoreDeviceInventory = HospitalManagementSystem.Domain.DeviceInventory;
using DTODeviceInventoryIn = HospitalManagementSystem.Application.InputDeviceInventoryDTO;
using DTODeviceInventoryOut = HospitalManagementSystem.Application.OutputDeviceInventoryDTO;

namespace HospitalManagementSystem.ServiceProvider;

public class DeviceInventoryServiceProvider : ServiceProviderBase<DTODeviceInventoryOut, DTODeviceInventoryIn, CoreDeviceInventory>, IDeviceInventoryServiceProvider
{
    public DeviceInventoryServiceProvider(IDeviceInventoryDataProvider dataProvider, IMapper mapper) : base(dataProvider, mapper)
    {
    }
}