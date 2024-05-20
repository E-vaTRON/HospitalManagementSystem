using CoreUserSpecialization = IdentitySystem.Domain.UserSpecialization;
using DTOUserSpecialization = IdentitySystem.Application.UserSpecializationDTO;

namespace IdentitySystem.ServiceProvider;

public class UserSpecializationServiceProvider : ServiceProviderBase<DTOUserSpecialization, CoreUserSpecialization>, IUserSpecializationServiceProvider
{
    public UserSpecializationServiceProvider(IUserSpecializationDataProvider dataProvider, IMapper mapper) : base(dataProvider, mapper)
    {
    }
}