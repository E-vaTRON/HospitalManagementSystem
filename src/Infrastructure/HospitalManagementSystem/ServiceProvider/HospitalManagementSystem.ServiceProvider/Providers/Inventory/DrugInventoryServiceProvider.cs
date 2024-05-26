using CoreDrugInventory = HospitalManagementSystem.Domain.DrugInventory;
using DTODrugInventoryIn = HospitalManagementSystem.Application.InputDrugInventoryDTO;
using DTODrugInventoryOut = HospitalManagementSystem.Application.OutputDrugInventoryDTO;

namespace HospitalManagementSystem.ServiceProvider;

public class DrugInventoryServiceProvider : ServiceProviderBase<DTODrugInventoryOut, DTODrugInventoryIn, CoreDrugInventory>, IDrugInventoryServiceProvider
{
    public DrugInventoryServiceProvider(IDrugInventoryDataProvider dataProvider, IMapper mapper) : base(dataProvider, mapper)
    {
    }
}
