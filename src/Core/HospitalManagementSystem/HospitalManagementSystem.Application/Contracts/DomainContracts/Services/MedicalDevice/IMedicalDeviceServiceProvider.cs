namespace HospitalManagementSystem.Application;

public interface IMedicalDeviceServiceProvider : IServiceProviderBase<OutputMedicalDeviceDTO, InputMedicalDeviceDTO, string>
{
    Task<IEnumerable<OutputMedicalDeviceDTO>> FindAllWithIncludedAsync(CancellationToken cancellationToken = default!);
}
