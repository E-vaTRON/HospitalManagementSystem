using DTOICDCodeIn = HospitalManagementSystem.Application.InputICDCodeDTO;
using DTOICDCodeOut = HospitalManagementSystem.Application.OutputICDCodeDTO;

namespace HospitalManagementSystem.REST;

public class ICDCodeController : BaseHMSController<DTOICDCodeOut, DTOICDCodeIn>
{
    public ICDCodeController(IICDCodeServiceProvider serviceProvider) : base(serviceProvider)
    {
    }
}
