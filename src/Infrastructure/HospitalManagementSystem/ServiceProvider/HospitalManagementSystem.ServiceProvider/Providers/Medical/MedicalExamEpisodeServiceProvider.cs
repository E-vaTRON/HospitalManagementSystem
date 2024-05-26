using CoreMedicalExamEpisode = HospitalManagementSystem.Domain.MedicalExamEpisode;
using DTOMedicalExamEpisodeIn = HospitalManagementSystem.Application.InputMedicalExamEpisodeDTO;
using DTOMedicalExamEpisodeOut = HospitalManagementSystem.Application.OutputMedicalExamEpisodeDTO;

namespace HospitalManagementSystem.ServiceProvider;

public class MedicalExamEpisodeServiceProvider : ServiceProviderBase<DTOMedicalExamEpisodeOut, DTOMedicalExamEpisodeIn, CoreMedicalExamEpisode>, IMedicalExamEpisodeServiceProvider
{
    public MedicalExamEpisodeServiceProvider(IMedicalExamEpisodeDataProvider dataProvider, IMapper mapper) : base(dataProvider, mapper)
    {
    }
}