using CoreMedicalExamEpisode = HospitalManagementSystem.Domain.MedicalExamEpisode;

namespace HospitalManagementSystem.ServiceProvider;

public class MedicalExamEpisodeServiceProvider : ServiceProviderBase<CoreMedicalExamEpisode>, IMedicalExamEpisodeServiceProvider
{
    public MedicalExamEpisodeServiceProvider(IMedicalExamEpisodeDataProvider dataProvider) : base(dataProvider)
    {
    }
}
