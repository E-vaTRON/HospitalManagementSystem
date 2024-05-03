using CoreTreatment = HospitalManagementSystem.Domain.Treatment;

namespace HospitalManagementSystem.ServiceProvider;

public class TreatmentServiceProvider : ServiceProviderBase<CoreTreatment>, ITreatmentServiceProvider
{
    public TreatmentServiceProvider(TreatmentDataProvider dataProvider) : base(dataProvider)
    {
    }
}
