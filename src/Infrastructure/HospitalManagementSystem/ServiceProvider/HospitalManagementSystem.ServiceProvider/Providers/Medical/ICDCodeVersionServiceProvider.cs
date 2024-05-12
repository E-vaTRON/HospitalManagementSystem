using CoreICDCodeVersion = HospitalManagementSystem.Domain.ICDCodeVersion;
using DTOICDCodeVersion = HospitalManagementSystem.Application.ICDCodeVersionDTO;

namespace HospitalManagementSystem.ServiceProvider;

public class ICDCodeVersionServiceProvider : ServiceProviderBase<DTOICDCodeVersion, CoreICDCodeVersion>, IICDCodeVersionServiceProvider
{
    public ICDCodeVersionServiceProvider(IICDCodeVersionDataProvider dataProvider, IMapper mapper) : base(dataProvider, mapper)
    {
    }
}
