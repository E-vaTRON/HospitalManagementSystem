using DTOServiceIn = HospitalManagementSystem.Application.InputServiceDTO;
using DTOServiceOut = HospitalManagementSystem.Application.OutputServiceDTO;

namespace HospitalManagementSystem.REST;

public class ServiceController : BaseHMSController<DTOServiceOut, DTOServiceIn>
{
    public ServiceController(IServiceServiceProvider serviceProvider) : base(serviceProvider)
    {
    }
}