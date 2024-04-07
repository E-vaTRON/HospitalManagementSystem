using CoreDeviceService = HospitalManagementSystem.Domain.DeviceService;
using DataDeviceService = HospitalManagementSystem.DataProvider.DeviceService;

namespace HospitalManagementSystem.DataProvider;

public class DeviceServiceDataProvider<TDbContext> : DataProviderBase<TDbContext, CoreDeviceService, DataDeviceService>, IDeviceServiceDataProvider
    where TDbContext : DbContext
{
    public DeviceServiceDataProvider(TDbContext context, IMapper mapper) : base(context, mapper)
    {
    }
}
