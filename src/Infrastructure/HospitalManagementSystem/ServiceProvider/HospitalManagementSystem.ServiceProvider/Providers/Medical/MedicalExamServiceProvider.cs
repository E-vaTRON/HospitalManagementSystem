using CoreMedicalExam = HospitalManagementSystem.Domain.MedicalExam;
using DTOMedicalExamIn = HospitalManagementSystem.Application.InputMedicalExamDTO;
using DTOMedicalExamOut = HospitalManagementSystem.Application.OutputMedicalExamDTO;

namespace HospitalManagementSystem.ServiceProvider;

public class MedicalExamServiceProvider : ServiceProviderBase<DTOMedicalExamOut, DTOMedicalExamIn, CoreMedicalExam>, IMedicalExamServiceProvider
{
    public MedicalExamServiceProvider(IMedicalExamDataProvider dataProvider, IMapper mapper) : base(dataProvider, mapper)
    {
    }
}
