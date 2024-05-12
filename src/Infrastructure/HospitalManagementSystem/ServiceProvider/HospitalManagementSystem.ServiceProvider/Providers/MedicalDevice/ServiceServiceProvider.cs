using CoreService = HospitalManagementSystem.Domain.Service;
using DTOService = HospitalManagementSystem.Application.ServiceDTO;

namespace HospitalManagementSystem.ServiceProvider;

public class ServiceServiceProvider : ServiceProviderBase<DTOService, CoreService>, IServiceServiceProvider
{
    public ServiceServiceProvider(IServiceDataProvider dataProvider, IMapper mapper) : base(dataProvider, mapper)
    {
    }
}
