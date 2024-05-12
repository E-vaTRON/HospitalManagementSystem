using CoreMedicalExam = HospitalManagementSystem.Domain.MedicalExam;
using DTOMedicalExam = HospitalManagementSystem.Application.MedicalExamDTO;

namespace HospitalManagementSystem.ServiceProvider;

public class MedicalExamServiceProvider : ServiceProviderBase<DTOMedicalExam, CoreMedicalExam>, IMedicalExamServiceProvider
{
    public MedicalExamServiceProvider(IMedicalExamDataProvider dataProvider, IMapper mapper) : base(dataProvider, mapper)
    {
    }
}
