using CoreICDCode = HospitalManagementSystem.Domain.ICDCode;

namespace HospitalManagementSystem.ServiceProvider;

public class ICDCodeServiceProvider : ServiceProviderBase<CoreICDCode>, IICDCodeServiceProvider
{
    public ICDCodeServiceProvider(ICDCodeDataProvider dataProvider) : base(dataProvider)
    {
    }
}
