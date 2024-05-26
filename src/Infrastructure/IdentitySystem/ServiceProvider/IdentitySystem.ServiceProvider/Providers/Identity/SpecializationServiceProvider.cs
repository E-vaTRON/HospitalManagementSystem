using CoreSpecialization = IdentitySystem.Domain.Specialization;
using DTOSpecializationIn = IdentitySystem.Application.InputSpecializationDTO;
using DTOSpecializationOut = IdentitySystem.Application.OutputSpecializationDTO;

namespace IdentitySystem.ServiceProvider;

public class SpecializationServiceProvider : ServiceProviderBase<DTOSpecializationOut, DTOSpecializationIn, CoreSpecialization>, ISpecializationServiceProvider
{
    public SpecializationServiceProvider(ISpecializationDataProvider dataProvider, IMapper mapper) : base(dataProvider, mapper)
    {
    }
}