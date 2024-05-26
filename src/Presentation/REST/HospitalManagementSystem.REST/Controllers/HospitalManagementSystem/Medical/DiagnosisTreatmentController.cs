using DTODiagnosisTreatmentIn = HospitalManagementSystem.Application.InputDiagnosisTreatmentDTO;
using DTODiagnosisTreatmentOut = HospitalManagementSystem.Application.OutputDiagnosisTreatmentDTO;

namespace HospitalManagementSystem.REST;

public class DiagnosisTreatmentController : BaseHMSController<DTODiagnosisTreatmentOut, DTODiagnosisTreatmentIn>
{
    public DiagnosisTreatmentController(IDiagnosisTreatmentServiceProvider serviceProvider) : base(serviceProvider)
    {
    }
}