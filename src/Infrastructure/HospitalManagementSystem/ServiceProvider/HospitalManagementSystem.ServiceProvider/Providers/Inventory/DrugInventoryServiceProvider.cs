using CoreDrugInventory = HospitalManagementSystem.Domain.DrugInventory;
using DTODrugInventory = HospitalManagementSystem.Application.DrugInventoryDTO;

namespace HospitalManagementSystem.ServiceProvider;

public class DrugInventoryServiceProvider : ServiceProviderBase<DTODrugInventory, CoreDrugInventory>, IDrugInventoryServiceProvider
{
    public DrugInventoryServiceProvider(IDrugInventoryDataProvider dataProvider, IMapper mapper) : base(dataProvider, mapper)
    {
    }
}
