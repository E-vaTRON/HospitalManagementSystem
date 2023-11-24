namespace HospitalManagementSystem.Application;

public interface IDeviceServiceRepository : IBaseRepository<DeviceService>
{
    new IQueryable<DeviceService> FindAll(Expression<Func<DeviceService, bool>>? predicate = null);

    new Task<DeviceService?> FindByIdAsync(string id, CancellationToken cancellationToken = default);
}
