using CoreDiseases = HospitalManagementSystem.Domain.Diseases;

namespace HospitalManagementSystem.ServiceProvider;

public class DiseasesServiceProvider : ServiceProviderBase<CoreDiseases>, IDiseasesServiceProvider
{
    public DiseasesServiceProvider(IDiseasesDataProvider dataProvider) : base(dataProvider)
    {
    }
}
