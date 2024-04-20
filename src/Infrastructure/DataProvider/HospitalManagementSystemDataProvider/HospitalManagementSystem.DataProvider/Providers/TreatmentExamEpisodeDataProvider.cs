using CoreTreatmentExamEpisode = HospitalManagementSystem.Domain.TreatmentExamEpisode;
using DataTreatmentExamEpisode = HospitalManagementSystem.DataProvider.TreatmentExamEpisode;

namespace HospitalManagementSystem.DataProvider;

public class TreatmentExamEpisodeDataProvider : DataProviderBase<CoreTreatmentExamEpisode, DataTreatmentExamEpisode>, ITreatmentExamEpisodeServiceProvider
{
    public TreatmentExamEpisodeDataProvider(HospitalManagementSystemDbContext context, IMapper mapper) : base(context, mapper)
    {
    }
}
