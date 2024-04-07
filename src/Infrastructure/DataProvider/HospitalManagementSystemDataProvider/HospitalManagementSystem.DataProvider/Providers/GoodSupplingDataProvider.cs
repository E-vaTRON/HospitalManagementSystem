using CoreGoodSuppling = HospitalManagementSystem.Domain.GoodSuppling;
using DataGoodSuppling = HospitalManagementSystem.DataProvider.GoodSuppling;

namespace HospitalManagementSystem.DataProvider;

public class GoodSupplingDataProvider<TDbContext> : DataProviderBase<TDbContext, CoreGoodSuppling, DataGoodSuppling>, IGoodSupplingDataProvider
    where TDbContext : DbContext
{
    public GoodSupplingDataProvider(TDbContext context, IMapper mapper) : base(context, mapper)
    {
    }
}
