namespace HospitalManagementSystem.ServiceProvider;

public class InventoryRepository : BaseRepository<Domain.DrugInventory>, IInventoryRepository
{
    public InventoryRepository(HospitalManagementSystemDbContext context) : base(context) { }
}
