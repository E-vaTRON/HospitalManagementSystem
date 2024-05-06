using CoreMedicalExamEpisode = HospitalManagementSystem.Domain.MedicalExamEpisode;
using DataMedicalExamEpisode = HospitalManagementSystem.DataProvider.MedicalExamEpisode;

namespace HospitalManagementSystem.DataProvider;

public class MedicalExamEpisodeDataProvider : DataProviderBase<CoreMedicalExamEpisode, DataMedicalExamEpisode>, IMedicalExamEpisodeDataProvider
{
    public MedicalExamEpisodeDataProvider(HospitalManagementSystemDbContext context, IMapper mapper) : base(context, mapper)
    {
    }
}
