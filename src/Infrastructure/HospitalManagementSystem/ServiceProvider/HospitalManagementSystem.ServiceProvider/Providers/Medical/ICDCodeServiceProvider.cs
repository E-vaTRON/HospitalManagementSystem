using CoreICDCode = HospitalManagementSystem.Domain.ICDCode;
using DTOICDCodeIn = HospitalManagementSystem.Application.InputICDCodeDTO;
using DTOICDCodeOut = HospitalManagementSystem.Application.OutputICDCodeDTO;

namespace HospitalManagementSystem.ServiceProvider;

public class ICDCodeServiceProvider : ServiceProviderBase<DTOICDCodeOut, DTOICDCodeIn, CoreICDCode>, IICDCodeServiceProvider
{
    public ICDCodeServiceProvider(IICDCodeDataProvider dataProvider, IMapper mapper) : base(dataProvider, mapper)
    {
    }
}
