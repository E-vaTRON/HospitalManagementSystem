using DTODiagnosisIn = HospitalManagementSystem.Application.InputDiagnosisDTO;
using DTODiagnosisOut = HospitalManagementSystem.Application.OutputDiagnosisDTO;

namespace HospitalManagementSystem.REST;

public class DiagnosisController : BaseHMSController<DTODiagnosisOut, DTODiagnosisIn>
{
    public DiagnosisController(IDiagnosisServiceProvider serviceProvider) : base(serviceProvider)
    {
    }
}