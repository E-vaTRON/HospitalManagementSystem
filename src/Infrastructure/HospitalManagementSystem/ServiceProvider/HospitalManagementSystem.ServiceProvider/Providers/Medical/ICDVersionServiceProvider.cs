using CoreICDVersion = HospitalManagementSystem.Domain.ICDVersion;
using DTOICDVersion = HospitalManagementSystem.Application.ICDVersionDTO;

namespace HospitalManagementSystem.ServiceProvider;

public class ICDVersionServiceProvider : ServiceProviderBase<DTOICDVersion, CoreICDVersion>, IICDVersionServiceProvider
{
    public ICDVersionServiceProvider(IICDVersionDataProvider dataProvider, IMapper mapper) : base(dataProvider, mapper)
    {
    }
}
