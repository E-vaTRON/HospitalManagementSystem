using CoreICDVersion = HospitalManagementSystem.Domain.ICDVersion;

namespace HospitalManagementSystem.ServiceProvider;

public class ICDVersionServiceProvider : ServiceProviderBase<CoreICDVersion>, IICDVersionServiceProvider
{
    public ICDVersionServiceProvider(IICDVersionDataProvider dataProvider) : base(dataProvider)
    {
    }
}
