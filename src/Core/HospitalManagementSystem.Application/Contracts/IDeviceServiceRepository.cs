namespace HospitalManagementSystem.Application;

public interface IDeviceServiceRepository : IBaseRepository<MedicalDevice>
{
    new IQueryable<MedicalDevice> FindAll(Expression<Func<MedicalDevice, bool>>? predicate = null);

    new Task<MedicalDevice?> FindByIdAsync(string id, CancellationToken cancellationToken = default);
}
