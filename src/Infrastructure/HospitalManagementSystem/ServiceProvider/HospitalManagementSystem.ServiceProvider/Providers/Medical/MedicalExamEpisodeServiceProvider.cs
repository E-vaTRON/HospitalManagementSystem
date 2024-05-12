using CoreMedicalExamEpisode = HospitalManagementSystem.Domain.MedicalExamEpisode;
using DTOMedicalExamEpisode = HospitalManagementSystem.Application.MedicalExamEpisodeDTO;

namespace HospitalManagementSystem.ServiceProvider;

public class MedicalExamEpisodeServiceProvider : ServiceProviderBase<DTOMedicalExamEpisode, CoreMedicalExamEpisode>, IMedicalExamEpisodeServiceProvider
{
    public MedicalExamEpisodeServiceProvider(IMedicalExamEpisodeDataProvider dataProvider, IMapper mapper) : base(dataProvider, mapper)
    {
    }
}
