using CoreSpecialization = IdentitySystem.Domain.Specialization;
using DataSpecialization = IdentitySystem.DataProvider.Specialization;

namespace IdentitySystem.DataProvider;

public class SpecializationDataProvider : DataProviderBase<CoreSpecialization, DataSpecialization>, ISpecializationDataProvider
{
    public SpecializationDataProvider(IdentitySystemDbContext context, IMapper mapper) : base(context, mapper)
    {
    }

    public Task<IdentityResult> SetAsync(InputSpecializationDTO test)
    {
        throw new NotImplementedException();
    }
}
