using CoreMedicalExamEposode = HospitalManagementSystem.Domain.MedicalExamEposode;
using DataMedicalExamEposode = HospitalManagementSystem.DataProvider.MedicalExamEposode;

namespace HospitalManagementSystem.DataProvider;

public class MedicalExamEposodeDataProvider<TDbContext> : DataProviderBase<TDbContext, CoreMedicalExamEposode, DataMedicalExamEposode>, IMedicalExamEposodeDataProvider
    where TDbContext : DbContext
{
    public MedicalExamEposodeDataProvider(TDbContext context, IMapper mapper) : base(context, mapper)
    {
    }
}
