using CoreDrugInventory = HospitalManagementSystem.Domain.DrugInventory;
using DataDrugInventory = HospitalManagementSystem.DataProvider.DrugInventory;

namespace HospitalManagementSystem.DataProvider
{
    public class DrugInventoryDataProvider : DataProviderBase<CoreDrugInventory, DataDrugInventory>, IDrugInventoryDataProvider
    {
        public DrugInventoryDataProvider(HospitalManagementSystemDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
