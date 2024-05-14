using CoreSpecialization = IdentitySystem.Domain.Specialization;
using DTOSpecialization = IdentitySystem.Application.SpecializationDTO;

namespace IdentitySystem.ServiceProvider;

public class SpecializationServiceProvider : ServiceProviderBase<DTOSpecialization, CoreSpecialization>, ISpecializationServiceProvider
{
    public SpecializationServiceProvider(ISpecializationDataProvider dataProvider, IMapper mapper) : base(dataProvider, mapper)
    {
    }
}
