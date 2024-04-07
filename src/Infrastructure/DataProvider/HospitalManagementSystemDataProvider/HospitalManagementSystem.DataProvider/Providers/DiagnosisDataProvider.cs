using CoreDiagnosis = HospitalManagementSystem.Domain.Diagnosis;
using DataDiagnosis = HospitalManagementSystem.DataProvider.Diagnosis;

namespace HospitalManagementSystem.DataProvider
{
    public class DiagnosisDataProvider : DataProviderBase<CoreDiagnosis, DataDiagnosis>, IDiagnosisDataProvider
    {
        public DiagnosisDataProvider(HospitalManagementSystemDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
