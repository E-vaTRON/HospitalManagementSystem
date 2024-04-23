using CoreMedicalExam = HospitalManagementSystem.Domain.MedicalExam;
using DataMedicalExam = HospitalManagementSystem.DataProvider.MedicalExam;

namespace HospitalManagementSystem.DataProvider;

public class MedicalExamDataProvider : DataProviderBase<CoreMedicalExam, DataMedicalExam>, IMedicalExamDataProvider
{
    public MedicalExamDataProvider(HospitalManagementSystemDbContext context, IMapper mapper) : base(context, mapper)
    {
    }
}