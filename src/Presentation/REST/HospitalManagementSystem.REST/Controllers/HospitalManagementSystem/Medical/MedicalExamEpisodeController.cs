using DTOMedicalExamEpisodeIn = HospitalManagementSystem.Application.InputMedicalExamEpisodeDTO;
using DTOMedicalExamEpisodeOut = HospitalManagementSystem.Application.OutputMedicalExamEpisodeDTO;

namespace HospitalManagementSystem.REST;
public class MedicalExamEpisodeController : BaseHMSController<DTOMedicalExamEpisodeOut, DTOMedicalExamEpisodeIn>
{
    public MedicalExamEpisodeController(IMedicalExamEpisodeServiceProvider serviceProvider) : base(serviceProvider)
    {
    }
}