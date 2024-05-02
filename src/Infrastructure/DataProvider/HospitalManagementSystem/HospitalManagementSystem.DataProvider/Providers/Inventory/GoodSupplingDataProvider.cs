using CoreGoodSuppling = HospitalManagementSystem.Domain.GoodSuppling;
using DataGoodSuppling = HospitalManagementSystem.DataProvider.GoodSuppling;

namespace HospitalManagementSystem.DataProvider;

public class GoodSupplingDataProvider : DataProviderBase<CoreGoodSuppling, DataGoodSuppling>, IGoodSupplingDataProvider
{
    public GoodSupplingDataProvider(HospitalManagementSystemDbContext context, IMapper mapper) : base(context, mapper)
    {
    }
}
