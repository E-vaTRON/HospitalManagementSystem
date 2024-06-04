namespace HospitalManagementSystem.Application;

public interface IDeviceServiceDataProvider : IDataProviderBase<DeviceService, string>
{
    Task<IList<DeviceService>> GetByMultipleServiceIdIncludeDeviceAsync(string[] userIds);

    Task<IList<DeviceService>> GetByServiceIdIncludeDeviceAsync(string userId);
}
