using CoreDiagnosisTreatment = HospitalManagementSystem.Domain.DiagnosisTreatment;

namespace HospitalManagementSystem.ServiceProvider;

public class DiagnosisTreatmentServiceProvider : ServiceProviderBase<CoreDiagnosisTreatment>, IDiagnosisTreatmentServiceProvider
{
    public DiagnosisTreatmentServiceProvider(DiagnosisTreatmentDataProvider dataProvider) : base(dataProvider)
    {
    }
}
