using CoreSpecialization = IdentitySystem.Domain.Specialization;
using DataSpecialization = IdentitySystem.DataProvider.Specialization;

namespace IdentitySystem.ServiceProvider;

public class SpecializationServiceProvider : ServiceProviderBase<CoreSpecialization>, ISpecializationServiceProvider
{
    public SpecializationServiceProvider(ISpecializationDataProvider dataProvider) : base(dataProvider)
    {
    }
}
