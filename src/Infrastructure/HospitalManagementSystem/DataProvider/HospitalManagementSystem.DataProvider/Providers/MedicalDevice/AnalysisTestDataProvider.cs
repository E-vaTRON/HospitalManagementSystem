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
    protected virtual async Task<IEnumerable<CoreAnalysisTest>> InternalFindByIdIncludeServiceAsync(string[] id, CancellationToken cancellationToken = default)
    {
        var mId = ParseIds(id!);
        var query = await GetQueryableAsync(false, cancellationToken);

        return await query.Include(x => x.DeviceService.Service)
                          .WhereIf(id != null, service => id!.Contains(service.Id))
                          .ToListAsync(cancellationToken);
    }
    #endregion

    #region [ Public - Methods ]
    public async Task<IList<CoreAnalysisTest>> GetMultipleByIdIncludeServiceAsync(string[] ids, CancellationToken cancellationToken = default)
    {
        var analysisTests = await InternalFindByIdIncludeServiceAsync(ids);
        ArgumentNullException.ThrowIfNull(analysisTests, nameof(analysisTests));
        return analysisTests.ToList();
    }

    public async Task<CoreAnalysisTest> GetByIdIncludeServiceAsync(string id, CancellationToken cancellationToken = default)
    {
        var analysisTests = await InternalFindByIdIncludeServiceAsync(new string[] { id });
        ArgumentNullException.ThrowIfNull(analysisTests, nameof(analysisTests));
        return analysisTests.First();
    }
    #endregion
}
