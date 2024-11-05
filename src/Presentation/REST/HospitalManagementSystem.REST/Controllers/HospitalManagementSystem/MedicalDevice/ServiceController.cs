using DTOServiceIn = HospitalManagementSystem.Application.InputMedicalServiceDTO;
using DTOServiceOut = HospitalManagementSystem.Application.OutputMedicalServiceDTO;

namespace HospitalManagementSystem.REST;

public class ServiceController : BaseHMSController<DTOServiceOut, DTOServiceIn>
{
    public ServiceController(IMedicalServiceServicesProvider serviceProvider) : base(serviceProvider)
    {
    }
}