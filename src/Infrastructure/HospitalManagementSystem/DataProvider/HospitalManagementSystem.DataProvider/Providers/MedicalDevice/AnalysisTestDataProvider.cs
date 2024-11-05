using CoreAnalysisTest = HospitalManagementSystem.Domain.AnalysisTest;
using DataAnalysisTest = HospitalManagementSystem.DataProvider.AnalysisTest;

namespace HospitalManagementSystem.DataProvider;

public class AnalysisTestDataProvider : DataProviderBase<CoreAnalysisTest, DataAnalysisTest>, IAnalysisTestDataProvider
{
    #region [ CTor ]
    public AnalysisTestDataProvider(HospitalManagementSystemDbContext context, IMapper mapper) : base(context, mapper)
    {
    }
    #endregion

    #region [ Internal Methods ]
    protected virtual async Task<IEnumerable<CoreAnalysisTest>> InternalGetAllIncludeDeviceAsync(Expression<Func<CoreAnalysisTest, bool>>? predicate = null, CancellationToken cancellationToken = default)
    {
        var query = await GetQueryableAsync(false, cancellationToken);

        return await query.Include(x => x.DeviceInventory)
                          .ToListAsync(cancellationToken);
    }

    protected virtual async Task<IEnumerable<CoreAnalysisTest>> InternalFindByIdIncludeDeviceAsync(string[] id, CancellationToken cancellationToken = default)
    {
        var mId = ParseIds(id!);
        var query = await GetQueryableAsync(false, cancellationToken);

        return await query.Include(x => x.DeviceInventory)
                          .WhereIf(id != null, service => id!.Contains(service.Id))
                          .ToListAsync(cancellationToken);
    }
    #endregion

    #region [ Public - Methods ]
    public async Task<IList<CoreAnalysisTest>> GetAllIncludeDeviceAsync()
    {
        var analysisTests = await InternalGetAllIncludeDeviceAsync();
        ArgumentNullException.ThrowIfNull(analysisTests, nameof(analysisTests));
        return analysisTests.ToList();
    }

    public async Task<IList<CoreAnalysisTest>> GetMultipleByIdIncludeDeviceAsync(string[] ids, CancellationToken cancellationToken = default)
    {
        var analysisTests = await InternalFindByIdIncludeDeviceAsync(ids);
        ArgumentNullException.ThrowIfNull(analysisTests, nameof(analysisTests));
        return analysisTests.ToList();
    }

    public async Task<CoreAnalysisTest> GetByIdIncludeDeviceAsync(string id, CancellationToken cancellationToken = default)
    {
        var analysisTests = await InternalFindByIdIncludeDeviceAsync(new string[] { id });
        ArgumentNullException.ThrowIfNull(analysisTests, nameof(analysisTests));
        return analysisTests.First();
    }
    #endregion
}
