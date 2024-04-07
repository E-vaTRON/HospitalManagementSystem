using CoreDeviceService = HospitalManagementSystem.Domain.DeviceService;
using DataDeviceService = HospitalManagementSystem.DataProvider.DeviceService;

namespace HospitalManagementSystem.DataProvider
{
    public class DeviceServiceDataProvider : DataProviderBase<CoreDeviceService, DataDeviceService>, IDeviceServiceDataProvider
    {
        public DeviceServiceDataProvider(HospitalManagementSystemDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
