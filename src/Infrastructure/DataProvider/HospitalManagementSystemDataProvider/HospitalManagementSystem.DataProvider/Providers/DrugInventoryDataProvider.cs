using Microsoft.EntityFrameworkCore;
using CoreDrugInventory = HospitalManagementSystem.Domain.DrugInventory;
using DataDrugInventory = HospitalManagementSystem.DataProvider.DrugInventory;

namespace HospitalManagementSystem.DataProvider;

public class DrugInventoryDataProvider<TDbContext> : DataProviderBase<TDbContext, CoreDrugInventory, DataDrugInventory>, IDrugInventoryDataProvider
    where TDbContext : DbContext
{
    public DrugInventoryDataProvider(TDbContext context, IMapper mapper) : base(context, mapper)
    {
    }
}
