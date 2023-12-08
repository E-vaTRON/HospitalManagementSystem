namespace HospitalManagementSystem.ServiceProvider;

public class DeviceServiceRepository : BaseRepository<Domain.MedicalDevice>, IDeviceServiceRepository
{
    public DeviceServiceRepository(HospitalManagementSystemDbContext context) : base(context) { }

    public override IQueryable<Domain.MedicalDevice> FindAll(Expression<Func<Domain.MedicalDevice, bool>>? predicate = null)
        => _dbSet.WhereIf(predicate != null, predicate!)
                 .Include(b => b.AnalyzationTests);


    public override async Task<Domain.MedicalDevice?> FindByIdAsync(string id, CancellationToken cancellationToken = default)
        => await FindAll(b => b.Id == id)
                .FirstOrDefaultAsync(cancellationToken);

}
