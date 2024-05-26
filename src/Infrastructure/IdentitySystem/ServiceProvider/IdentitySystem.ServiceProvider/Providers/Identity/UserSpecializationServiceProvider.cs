using CoreUserSpecialization = IdentitySystem.Domain.UserSpecialization;
using DTOUserSpecializationIn = IdentitySystem.Application.InputUserSpecializationDTO;
using DTOUserSpecializationOut = IdentitySystem.Application.OutputUserSpecializationDTO;

namespace IdentitySystem.ServiceProvider;

public class UserSpecializationServiceProvider : ServiceProviderBase<DTOUserSpecializationOut, DTOUserSpecializationIn, CoreUserSpecialization>, IUserSpecializationServiceProvider
{
    public UserSpecializationServiceProvider(IUserSpecializationDataProvider dataProvider, IMapper mapper) : base(dataProvider, mapper)
    {
    }
}