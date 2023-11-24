namespace HospitalManagementSystem.ServiceProvider;

public class DeviceServiceRepository : BaseRepository<Domain.DeviceService>, IDeviceServiceRepository
{
    public DeviceServiceRepository(HospitalManagementSystemDbContext context) : base(context) { }

    public override IQueryable<Domain.DeviceService> FindAll(Expression<Func<Domain.DeviceService, bool>>? predicate = null)
        => _dbSet.WhereIf(predicate != null, predicate!)
                 .Include(b => b.AnalyzationTests);


    public override async Task<Domain.DeviceService?> FindByIdAsync(string id, CancellationToken cancellationToken = default)
        => await FindAll(b => b.Id == id)
                .FirstOrDefaultAsync(cancellationToken);

}
