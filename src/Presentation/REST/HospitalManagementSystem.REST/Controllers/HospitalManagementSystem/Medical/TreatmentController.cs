using DTOTreatmentIn = HospitalManagementSystem.Application.InputTreatmentDTO;
using DTOTreatmentOut = HospitalManagementSystem.Application.OutputTreatmentDTO;

namespace HospitalManagementSystem.REST;

public class TreatmentController : BaseHMSController<DTOTreatmentOut, DTOTreatmentIn>
{
    public TreatmentController(ITreatmentServiceProvider serviceProvider) : base(serviceProvider)
    {
    }
}