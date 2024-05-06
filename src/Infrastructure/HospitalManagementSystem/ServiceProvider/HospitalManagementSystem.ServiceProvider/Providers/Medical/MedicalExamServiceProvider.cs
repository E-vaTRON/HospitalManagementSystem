using CoreMedicalExam = HospitalManagementSystem.Domain.MedicalExam;

namespace HospitalManagementSystem.ServiceProvider;

public class MedicalExamServiceProvider : ServiceProviderBase<CoreMedicalExam>, IMedicalExamServiceProvider
{
    public MedicalExamServiceProvider(IMedicalExamDataProvider dataProvider) : base(dataProvider)
    {
    }
}
