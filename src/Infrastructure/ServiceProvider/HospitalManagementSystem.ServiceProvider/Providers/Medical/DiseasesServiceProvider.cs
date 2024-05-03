using CoreDiseases = HospitalManagementSystem.Domain.Diseases;

namespace HospitalManagementSystem.ServiceProvider;

public class DiseasesServiceProvider : ServiceProviderBase<CoreDiseases>, IDiseasesServiceProvider
{
    public DiseasesServiceProvider(DiseasesDataProvider dataProvider) : base(dataProvider)
    {
    }
}
