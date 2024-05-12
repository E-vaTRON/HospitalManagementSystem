using CoreDeviceInventory = HospitalManagementSystem.Domain.DeviceInventory;
using DTODeviceInventory = HospitalManagementSystem.Application.DeviceInventoryDTO;

namespace HospitalManagementSystem.ServiceProvider;

public class DeviceInventoryServiceProvider : ServiceProviderBase<DTODeviceInventory, CoreDeviceInventory>, IDeviceInventoryServiceProvider
{
    public DeviceInventoryServiceProvider(IDeviceInventoryDataProvider dataProvider, IMapper mapper) : base(dataProvider, mapper)
    {
    }
}
