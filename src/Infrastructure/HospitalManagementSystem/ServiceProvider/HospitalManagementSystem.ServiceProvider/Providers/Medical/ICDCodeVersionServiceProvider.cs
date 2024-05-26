using CoreICDCodeVersion = HospitalManagementSystem.Domain.ICDCodeVersion;
using DTOICDCodeVersionIn = HospitalManagementSystem.Application.InputICDCodeVersionDTO;
using DTOICDCodeVersionOut = HospitalManagementSystem.Application.OutputICDCodeVersionDTO;

namespace HospitalManagementSystem.ServiceProvider;

public class ICDCodeVersionServiceProvider : ServiceProviderBase<DTOICDCodeVersionOut, DTOICDCodeVersionIn, CoreICDCodeVersion>, IICDCodeVersionServiceProvider
{
    public ICDCodeVersionServiceProvider(IICDCodeVersionDataProvider dataProvider, IMapper mapper) : base(dataProvider, mapper)
    {
    }
}
