using static OneOf.Types.TrueFalseOrNull;
using CoreDeviceService = HospitalManagementSystem.Domain.DeviceService;
using DataDeviceService = HospitalManagementSystem.DataProvider.DeviceService;

namespace HospitalManagementSystem.DataProvider;

public class DeviceServiceDataProvider: DataProviderBase<CoreDeviceService, DataDeviceService>, IDeviceServiceDataProvider
{
    #region [ CTor ]
    public DeviceServiceDataProvider(HospitalManagementSystemDbContext context, IMapper mapper) : base(context, mapper)
    {
    }
    #endregion

    #region [ Internal - Method ]    
    protected virtual async Task<IEnumerable<CoreDeviceService>> InternalGetByServiceIdIncludeDeviceAsync(string[] serviceId, CancellationToken cancellationToken =default)
    {
        var query = await GetQueryableAsync(false, cancellationToken);

        return await query.Include(ds => ds.DeviceInventory)
                          .Include(ds => ds.DeviceInventory.MedicalDevice)
                          .WhereIf(serviceId != null,ds => serviceId!.Contains(ds.ServiceId))
                          .ToListAsync(cancellationToken);
    }
    #endregion

    #region [ Public - Method ]
    public async Task<IList<CoreDeviceService>> GetByMultipleServiceIdIncludeDeviceAsync(string[] userIds)
    {
        var deviceServices = await InternalGetByServiceIdIncludeDeviceAsync(userIds);
        ArgumentNullException.ThrowIfNull(deviceServices, nameof(CoreDeviceService));
        return deviceServices.ToList();
    }

    public async Task<IList<CoreDeviceService>> GetByServiceIdIncludeDeviceAsync(string userId)
    {
        var deviceServices = await InternalGetByServiceIdIncludeDeviceAsync(new string[] { userId });
        ArgumentNullException.ThrowIfNull(deviceServices, nameof(CoreDeviceService));
        return deviceServices.ToList();
    }
    #endregion
}
