namespace HospitalManagementSystem.Application;

public interface IDeviceServiceServiceProvider : IServiceProviderBase<OutputDeviceServiceDTO, InputDeviceServiceDTO, string>
{
    Task<IList<OutputDeviceServiceDTO>> GetByMultipleServiceIdIncludeDeviceAsync(string[] userIds);

    Task<IList<OutputDeviceServiceDTO>> GetByServiceIdIncludeDeviceAsync(string userId);
}
