namespace HospitalManagementSystem.ServiceProvider;

public class StorageRepository : BaseRepository<Domain.Storage>, IStorageRepository
{
    public StorageRepository(HospitalManagementSystemDbContext context) : base(context) { }
}
