using CoreICDVersion = HospitalManagementSystem.Domain.ICDVersion;
using DTOICDVersionIn = HospitalManagementSystem.Application.InputICDVersionDTO;
using DTOICDVersionOut = HospitalManagementSystem.Application.OutputICDVersionDTO;

namespace HospitalManagementSystem.ServiceProvider;

public class ICDVersionServiceProvider : ServiceProviderBase<DTOICDVersionOut, DTOICDVersionIn, CoreICDVersion>, IICDVersionServiceProvider
{
    public ICDVersionServiceProvider(IICDVersionDataProvider dataProvider, IMapper mapper) : base(dataProvider, mapper)
    {
    }
}
