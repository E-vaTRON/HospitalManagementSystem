using CoreDrugInventory = HospitalManagementSystem.Domain.DrugInventory;

namespace HospitalManagementSystem.ServiceProvider;

public class DrugInventoryServiceProvider : ServiceProviderBase<CoreDrugInventory>, IDrugInventoryServiceProvider
{
    public DrugInventoryServiceProvider(DrugInventoryDataProvider dataProvider) : base(dataProvider)
    {
    }
}
