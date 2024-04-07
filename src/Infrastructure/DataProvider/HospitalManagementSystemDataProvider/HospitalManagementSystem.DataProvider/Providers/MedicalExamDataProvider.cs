using CoreMedicalExam = HospitalManagementSystem.Domain.MedicalExam;
using DataMedicalExam = HospitalManagementSystem.DataProvider.MedicalExam;

namespace HospitalManagementSystem.DataProvider;

public class MedicalExamDataProvider<TDbContext> : DataProviderBase<TDbContext, CoreMedicalExam, DataMedicalExam>, IMedicalExamDataProvider
    where TDbContext : DbContext
{
    public MedicalExamDataProvider(TDbContext context, IMapper mapper) : base(context, mapper)
    {
    }
}