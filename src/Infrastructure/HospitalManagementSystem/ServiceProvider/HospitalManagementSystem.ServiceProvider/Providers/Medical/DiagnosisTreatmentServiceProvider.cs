using CoreDiagnosisTreatment = HospitalManagementSystem.Domain.DiagnosisTreatment;

namespace HospitalManagementSystem.ServiceProvider;

public class DiagnosisTreatmentServiceProvider : ServiceProviderBase<CoreDiagnosisTreatment>, IDiagnosisTreatmentServiceProvider
{
    public DiagnosisTreatmentServiceProvider(IDiagnosisTreatmentDataProvider dataProvider) : base(dataProvider)
    {
    }
}
