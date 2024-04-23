using CoreService = HospitalManagementSystem.Domain.Service;
using DataService = HospitalManagementSystem.DataProvider.Service;

namespace HospitalManagementSystem.DataProvider;

public class ServiceDataProvider : DataProviderBase<CoreService, DataService>, IServiceDataProvider
{
    public ServiceDataProvider(HospitalManagementSystemDbContext context, IMapper mapper) : base(context, mapper)
    {
    }
}
