using CoreService = HospitalManagementSystem.Domain.Service;
using DataService = HospitalManagementSystem.DataProvider.Service;

namespace HospitalManagementSystem.DataProvider;

public class ServiceDataProvider : DataProviderBase<CoreService, DataService>, IServiceDataProvider
{
    #region [ CTor ]
    public ServiceDataProvider(HospitalManagementSystemDbContext context, IMapper mapper) : base(context, mapper)
    {
    }
    #endregion

    #region [ Internal Methods ]
    protected virtual async Task<IEnumerable<CoreService>> InternalFindAllIncludeAnalysisAsync(Expression<Func<CoreService, bool>>? predicate = null, CancellationToken cancellationToken = default)
    {
        var query = await GetQueryableAsync(false, cancellationToken);

        return await query.Include(x => x.DeviceServices)
                          .Include(x => x.DeviceServices).ThenInclude(y => y.AnalysisTests)
                          .WhereIf(predicate != null, predicate!)
                          .ToListAsync(cancellationToken);
    }
    #endregion

    #region [ Public Methods ]
    //public async Task<IList<CoreService>> GetBillByMultipleUserIdAsync(string[] userIds)
    //{
    //    var bills = await InternalFindByUserIdAsync(userIds);
    //    ArgumentNullException.ThrowIfNull(bills, nameof(CoreBill));
    //    return bills.ToList();
    //}
    #endregion
}
