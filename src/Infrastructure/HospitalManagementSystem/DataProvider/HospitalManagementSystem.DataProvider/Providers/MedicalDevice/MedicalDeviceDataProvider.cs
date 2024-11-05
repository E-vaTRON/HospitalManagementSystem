using CoreMedicalDevice = HospitalManagementSystem.Domain.MedicalDevice;
using DataMedicalDevice = HospitalManagementSystem.DataProvider.MedicalDevice;

namespace HospitalManagementSystem.DataProvider;

public class MedicalDeviceDataProvider : DataProviderBase<CoreMedicalDevice, DataMedicalDevice>, IMedicalDeviceDataProvider
{
    #region [ CTor ]
    public MedicalDeviceDataProvider(HospitalManagementSystemDbContext context, IMapper mapper) : base(context, mapper)
    {
    }
    #endregion

    #region [ Internal Methods ]
    protected virtual Task<IQueryable<CoreMedicalDevice>> GetQueryableIncludeRelatedAsync(bool asNoTracking = true, CancellationToken cancellationToken = default)
    {
        var query = DbSet.AsQueryable();
        if (asNoTracking)
            query = query.AsNoTracking();

        return Task.FromResult(query.Include(x => x.DeviceInventories)
                                    .ProjectTo<CoreMedicalDevice>(Mapper.ConfigurationProvider));
    }
    #endregion

    #region [ Public Methods ]
    public async Task<IEnumerable<CoreMedicalDevice>> FindAllWithIncludedAsync(CancellationToken cancellationToken)
    {
        var query = await GetQueryableIncludeRelatedAsync();

        return await query.ToListAsync(cancellationToken);
    }
    #endregion
}
