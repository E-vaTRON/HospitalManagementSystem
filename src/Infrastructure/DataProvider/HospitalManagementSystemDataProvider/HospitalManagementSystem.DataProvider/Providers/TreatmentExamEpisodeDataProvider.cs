using CoreTreatmentExamEpisode = HospitalManagementSystem.Domain.TreatmentExamEpisode;
using DataTreatmentExamEpisode = HospitalManagementSystem.DataProvider.TreatmentExamEpisode;

namespace HospitalManagementSystem.DataProvider;

public class TreatmentExamEpisodeDataProvider<TDbContext> : DataProviderBase<TDbContext, CoreTreatmentExamEpisode, DataTreatmentExamEpisode>, ITreatmentExamEpisodeDataProvider
    where TDbContext : DbContext
{
    public TreatmentExamEpisodeDataProvider(TDbContext context, IMapper mapper) : base(context, mapper)
    {
    }
}
