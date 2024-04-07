using CoreDiagnosis = HospitalManagementSystem.Domain.Diagnosis;
using DataDiagnosis = HospitalManagementSystem.DataProvider.Diagnosis;

namespace HospitalManagementSystem.DataProvider;

public class DiagnosisDataProvider<TDbContext> : DataProviderBase<TDbContext, CoreDiagnosis, DataDiagnosis>, IDiagnosisDataProvider
    where TDbContext : DbContext
{
    public DiagnosisDataProvider(TDbContext context, IMapper mapper) : base(context, mapper)
    {
    }
}
