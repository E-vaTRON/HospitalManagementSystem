using CoreGoodSuppling = HospitalManagementSystem.Domain.GoodSuppling;

namespace HospitalManagementSystem.ServiceProvider;

public class GoodSupplingServiceProvider : ServiceProviderBase<CoreGoodSuppling>, IGoodSupplingServiceProvider
{
    public GoodSupplingServiceProvider(GoodSupplingDataProvider dataProvider) : base(dataProvider)
    {
    }
}
