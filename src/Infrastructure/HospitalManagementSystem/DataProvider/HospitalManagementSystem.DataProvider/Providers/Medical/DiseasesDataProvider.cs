using CoreDiseases = HospitalManagementSystem.Domain.Diseases;
using DataDiseases = HospitalManagementSystem.DataProvider.Diseases;

namespace HospitalManagementSystem.DataProvider;

public class DiseasesDataProvider : DataProviderBase<CoreDiseases, DataDiseases>, IDiseasesDataProvider
{
    #region [ CTor ]
    public DiseasesDataProvider(HospitalManagementSystemDbContext context, IMapper mapper) : base(context, mapper)
    {
    }
    #endregion

    #region [ Internal Methods ]
    protected virtual Task<IQueryable<CoreDiseases>> GetQueryableIncludeICDCodedAsync(bool asNoTracking = true, CancellationToken cancellationToken = default)
    {
        var query = DbSet.AsQueryable();
        if (asNoTracking)
            query = query.AsNoTracking();

        return Task.FromResult(query.Include(x => x.ICDCodes)
                                    .ProjectTo<CoreDiseases>(Mapper.ConfigurationProvider));
    }
    #endregion

    #region [ Public Methods ]
    public async Task<IEnumerable<CoreDiseases>> FindAllWithIncludeAsync(CancellationToken cancellationToken)
    {
        var query = await GetQueryableIncludeICDCodedAsync();

        var test = await query.ToListAsync(cancellationToken);

        return test;
    }
    #endregion
}
