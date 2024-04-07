using CoreService = HospitalManagementSystem.Domain.Service;
using DataService = HospitalManagementSystem.DataProvider.Service;

namespace HospitalManagementSystem.DataProvider;

public class ServiceDataProvider<TDbContext> : DataProviderBase<TDbContext, CoreService, DataService>, IServiceDataProvider
    where TDbContext : DbContext
{
    public ServiceDataProvider(TDbContext context, IMapper mapper) : base(context, mapper)
    {
    }
}
