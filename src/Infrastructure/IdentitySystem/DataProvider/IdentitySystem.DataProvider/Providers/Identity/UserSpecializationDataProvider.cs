using CoreUserSpecialization = IdentitySystem.Domain.UserSpecialization;
using DataUserSpecialization = IdentitySystem.DataProvider.UserSpecialization;

namespace IdentitySystem.DataProvider;

public class UserSpecializationDataProvider: DataProviderBase<CoreUserSpecialization, DataUserSpecialization>, IUserSpecializationDataProvider
{
    public UserSpecializationDataProvider(IdentitySystemDbContext context, IMapper mapper) : base(context, mapper)
    {
    }
}
