using DTODrugPrescriptionIn = HospitalManagementSystem.Application.InputDrugPrescriptionDTO;
using DTODrugPrescriptionOut = HospitalManagementSystem.Application.OutputDrugPrescriptionDTO;

namespace HospitalManagementSystem.REST;
public class DrugPrescriptionController : BaseHMSController<DTODrugPrescriptionOut, DTODrugPrescriptionIn>
{
    public DrugPrescriptionController(IDrugPrescriptionServiceProvider serviceProvider) : base(serviceProvider)
    {
    }
}