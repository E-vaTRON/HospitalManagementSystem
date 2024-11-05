using static System.Runtime.InteropServices.JavaScript.JSType;
using CoreMedicalExamEpisode = HospitalManagementSystem.Domain.MedicalExamEpisode;
using DataMedicalExamEpisode = HospitalManagementSystem.DataProvider.MedicalExamEpisode;

namespace HospitalManagementSystem.DataProvider;

public class MedicalExamEpisodeDataProvider : DataProviderBase<CoreMedicalExamEpisode, DataMedicalExamEpisode>, IMedicalExamEpisodeDataProvider
{

    #region [ CTor ]
    public MedicalExamEpisodeDataProvider(HospitalManagementSystemDbContext context, IMapper mapper) : base(context, mapper)
    {
    }
    #endregion

    #region [ Internal - Methods ]
    protected virtual Task<IQueryable<CoreMedicalExamEpisode>> InternalGetQueryableIncludedAsync(bool asNoTracking = true, CancellationToken cancellationToken = default)
    {
        var query = DbSet.AsQueryable();
        if (asNoTracking)
            query = query.AsNoTracking();

        query.Include(x => x.AnalysisTests)
             .Include(x => x.DrugPrescriptions)
             .AsSplitQuery();

        return Task.FromResult(query.ProjectTo<CoreMedicalExamEpisode>(Mapper.ConfigurationProvider));
    }
    #endregion

    #region [ Public - Methods ]
    public async Task<IList<CoreMedicalExamEpisode>> FindByIdIncludedAsync(string[] ids, CancellationToken cancellationToken = default)
    {

        var query = await InternalGetQueryableIncludedAsync();

        ArgumentNullException.ThrowIfNull(query, nameof(CoreMedicalExamEpisode));

        return await query.Where(examEp => ids.Contains(examEp.Id))
                          .ToListAsync(cancellationToken);
    }

    public async Task<IEnumerable<CoreMedicalExamEpisode>> FindByMedicalExamIdAsync(string[] ids, CancellationToken cancellationToken = default)
    {
        var query = await GetQueryableAsync();

        return await query.Where(examEp => ids.Contains(examEp.MedicalExamId))
                          .ToListAsync(cancellationToken);
    }
    #endregion
}
