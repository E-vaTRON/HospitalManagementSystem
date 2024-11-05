namespace HospitalManagementSystem.Application;

public interface IMedicalDeviceDataProvider : IDataProviderBase<MedicalDevice, string>
{
    Task<IEnumerable<MedicalDevice>> FindAllWithIncludedAsync(CancellationToken cancellationToken);
}
