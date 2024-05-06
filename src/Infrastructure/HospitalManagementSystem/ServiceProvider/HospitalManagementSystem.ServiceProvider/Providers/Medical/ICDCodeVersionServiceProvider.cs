using CoreICDCodeVersion = HospitalManagementSystem.Domain.ICDCodeVersion;

namespace HospitalManagementSystem.ServiceProvider;

public class ICDCodeVersionServiceProvider : ServiceProviderBase<CoreICDCodeVersion>, IICDCodeVersionServiceProvider
{
    public ICDCodeVersionServiceProvider(ICDCodeVersionDataProvider dataProvider) : base(dataProvider)
    {
    }
}
