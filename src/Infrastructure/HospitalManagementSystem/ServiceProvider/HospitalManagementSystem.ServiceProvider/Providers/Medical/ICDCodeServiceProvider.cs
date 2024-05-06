using CoreICDCode = HospitalManagementSystem.Domain.ICDCode;

namespace HospitalManagementSystem.ServiceProvider;

public class ICDCodeServiceProvider : ServiceProviderBase<CoreICDCode>, IICDCodeServiceProvider
{
    public ICDCodeServiceProvider(IICDCodeDataProvider dataProvider) : base(dataProvider)
    {
    }
}
