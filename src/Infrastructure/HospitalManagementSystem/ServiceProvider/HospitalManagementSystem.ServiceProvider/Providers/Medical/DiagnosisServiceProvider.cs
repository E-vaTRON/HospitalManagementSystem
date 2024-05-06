using CoreDiagnosis = HospitalManagementSystem.Domain.Diagnosis;

namespace HospitalManagementSystem.ServiceProvider;

public class DiagnosisServiceProvider : ServiceProviderBase<CoreDiagnosis>, IDiagnosisServiceProvider
{
    public DiagnosisServiceProvider(IDiagnosisDataProvider dataProvider) : base(dataProvider)
    {
    }
}
