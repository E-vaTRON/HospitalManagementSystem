using CoreService = HospitalManagementSystem.Domain.Service;

namespace HospitalManagementSystem.ServiceProvider;

public class ServiceServiceProvider : ServiceProviderBase<CoreService>, IServiceServiceProvider
{
    public ServiceServiceProvider(IServiceDataProvider dataProvider) : base(dataProvider)
    {
    }
}
