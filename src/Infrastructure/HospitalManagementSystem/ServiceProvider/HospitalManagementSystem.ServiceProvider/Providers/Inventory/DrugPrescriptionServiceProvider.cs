using CoreDrugPrescription = HospitalManagementSystem.Domain.DrugPrescription;

namespace HospitalManagementSystem.ServiceProvider;

public class DrugPrescriptionServiceProvider : ServiceProviderBase<CoreDrugPrescription>, IDrugPrescriptionServiceProvider
{
    public DrugPrescriptionServiceProvider(DrugPrescriptionDataProvider dataProvider) : base(dataProvider)
    {
    }
}
