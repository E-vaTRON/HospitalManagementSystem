using CoreGoodSuppling = HospitalManagementSystem.Domain.GoodSuppling;
using DTOGoodSuppling = HospitalManagementSystem.Application.GoodSupplingDTO;

namespace HospitalManagementSystem.ServiceProvider;

public class GoodSupplingServiceProvider : ServiceProviderBase<DTOGoodSuppling, CoreGoodSuppling>, IGoodSupplingServiceProvider
{
    public GoodSupplingServiceProvider(IGoodSupplingDataProvider dataProvider, IMapper mapper) : base(dataProvider, mapper)
    {
    }
}
