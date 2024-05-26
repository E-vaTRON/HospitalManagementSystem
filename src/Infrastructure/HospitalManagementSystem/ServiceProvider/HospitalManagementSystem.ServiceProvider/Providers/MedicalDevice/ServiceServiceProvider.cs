using CoreService = HospitalManagementSystem.Domain.Service;
using DTOServiceIn = HospitalManagementSystem.Application.InputServiceDTO;
using DTOServiceOut = HospitalManagementSystem.Application.OutputServiceDTO;

namespace HospitalManagementSystem.ServiceProvider;

public class ServiceServiceProvider : ServiceProviderBase<DTOServiceOut, DTOServiceIn, CoreService>, IServiceServiceProvider
{
    public ServiceServiceProvider(IServiceDataProvider dataProvider, IMapper mapper) : base(dataProvider, mapper)
    {
    }
}
