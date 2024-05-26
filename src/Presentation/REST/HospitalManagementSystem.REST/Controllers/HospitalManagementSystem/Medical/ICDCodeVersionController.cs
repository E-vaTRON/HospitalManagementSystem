using DTOICDCodeVersionIn = HospitalManagementSystem.Application.InputICDCodeVersionDTO;
using DTOICDCodeVersionOut = HospitalManagementSystem.Application.OutputICDCodeVersionDTO;

namespace HospitalManagementSystem.REST;

public class ICDCodeVersionController : BaseHMSController<DTOICDCodeVersionOut, DTOICDCodeVersionIn>
{
    public ICDCodeVersionController(IICDCodeVersionServiceProvider serviceProvider) : base(serviceProvider)
    {
    }
}
