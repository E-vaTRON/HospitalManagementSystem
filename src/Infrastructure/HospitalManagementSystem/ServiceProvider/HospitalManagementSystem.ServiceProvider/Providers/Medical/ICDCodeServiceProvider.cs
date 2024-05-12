using CoreICDCode = HospitalManagementSystem.Domain.ICDCode;
using DTOICDCode = HospitalManagementSystem.Application.ICDCodeDTO;

namespace HospitalManagementSystem.ServiceProvider;

public class ICDCodeServiceProvider : ServiceProviderBase<DTOICDCode, CoreICDCode>, IICDCodeServiceProvider
{
    public ICDCodeServiceProvider(IICDCodeDataProvider dataProvider, IMapper mapper) : base(dataProvider, mapper)
    {
    }
}
