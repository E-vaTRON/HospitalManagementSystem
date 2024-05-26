using DTOICDVersionIn = HospitalManagementSystem.Application.InputICDVersionDTO;
using DTOICDVersionOut = HospitalManagementSystem.Application.OutputICDVersionDTO;

namespace HospitalManagementSystem.REST;

public class ICDVersionController : BaseHMSController<DTOICDVersionOut, DTOICDVersionIn>
{
    public ICDVersionController(IICDVersionServiceProvider serviceProvider) : base(serviceProvider)
    {
    }
}
