using CoreService = HospitalManagementSystem.Domain.Service;

namespace HospitalManagementSystem.ServiceProvider;

public class ServiceServiceProvider : ServiceProviderBase<CoreService>, IServiceServiceProvider
{
    public ServiceServiceProvider(ServiceDataProvider dataProvider) : base(dataProvider)
    {
    }
}
