using DTOMedicalExamIn = HospitalManagementSystem.Application.InputMedicalExamDTO;
using DTOMedicalExamOut = HospitalManagementSystem.Application.OutputMedicalExamDTO;

namespace HospitalManagementSystem.REST;

public class MedicalExamController : BaseHMSController<DTOMedicalExamOut, DTOMedicalExamIn>
{
    public MedicalExamController(IMedicalExamServiceProvider serviceProvider) : base(serviceProvider)
    {
    }
}