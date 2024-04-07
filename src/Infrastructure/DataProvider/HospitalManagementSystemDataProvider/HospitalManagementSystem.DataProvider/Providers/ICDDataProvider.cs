using CoreICD = HospitalManagementSystem.Domain.ICD;
using DataICD = HospitalManagementSystem.DataProvider.ICD;

namespace HospitalManagementSystem.DataProvider;

public class ICDDataProvider<TDbContext> : DataProviderBase<TDbContext, CoreICD, DataICD>, IICDDataProvider
    where TDbContext : DbContext
{
    public ICDDataProvider(TDbContext context, IMapper mapper) : base(context, mapper)
    {
    }
}
