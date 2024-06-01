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

    #region [ Internal Methods ]
    protected virtual async Task<IEnumerable<CoreMedicalExamEpisode>> InternalFindByIdIncludeRelatedEntitiesAsync(string[] id, CancellationToken cancellationToken = default)
    {
        var mId = ParseIds(id!);
        var query = await GetQueryableAsync(false, cancellationToken);

        return await query.Include(x => x.RoomAllocations)
                          .Include(x => x.DrugPrescriptions)
                          .Include(x => x.AnalysisTests)
                          .WhereIf(id != null, medicalExamEpisode => id!.Contains(medicalExamEpisode.Id))
                          .ToListAsync(cancellationToken);
    }
    #endregion

    #region [ Public - Methods ]
    public async Task<IList<CoreMedicalExamEpisode>> GetMedicalExamEpisodeByIdAsync(string id, CancellationToken cancellationToken = default)
    {
        var medicalExamEpisodes = await InternalFindByIdIncludeRelatedEntitiesAsync(new string[] { id });
        ArgumentNullException.ThrowIfNull(medicalExamEpisodes, nameof(CoreMedicalExamEpisode));
        return medicalExamEpisodes.ToList();
    }
    #endregion
}
