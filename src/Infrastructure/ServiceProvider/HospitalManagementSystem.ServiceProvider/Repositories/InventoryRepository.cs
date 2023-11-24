namespace HospitalManagementSystem.ServiceProvider;

public class InventoryRepository : BaseRepository<Domain.Inventory>, IInventoryRepository
{
    public InventoryRepository(HospitalManagementSystemDbContext context) : base(context) { }
}
