using CoreGoodSuppling = HospitalManagementSystem.Domain.GoodSuppling;
using DTOGoodSupplingIn = HospitalManagementSystem.Application.InputGoodSupplingDTO;
using DTOGoodSupplingOut = HospitalManagementSystem.Application.OutputGoodSupplingDTO;

namespace HospitalManagementSystem.ServiceProvider;

public class GoodSupplingServiceProvider : ServiceProviderBase<DTOGoodSupplingOut, DTOGoodSupplingIn, CoreGoodSuppling>, IGoodSupplingServiceProvider
{
    public GoodSupplingServiceProvider(IGoodSupplingDataProvider dataProvider, IMapper mapper) : base(dataProvider, mapper)
    {
    }
}