using CoreDrug = HospitalManagementSystem.Domain.Drug;

namespace HospitalManagementSystem.ServiceProvider;

public class DrugServiceProvider : ServiceProviderBase<CoreDrug>, IDrugServiceProvider
{
    public DrugServiceProvider(DrugDataProvider dataProvider) : base(dataProvider)
    {
    }
}
 