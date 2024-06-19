namespace HospitalManagementSystem.Domain;

public static class ServiceExtensions
{
    #region [ Private Methods ]
    private static Service AddDeviceService(this Service service, DeviceService deviceService)
    {
        ArgumentException.ThrowIfNullOrEmpty(nameof(deviceService));

        // Assuming DeviceInventoryId and ServiceId together should be unique
        if (service.DeviceServices.Any(x => x.DeviceInventoryId == deviceService.Id))
        {
            return service;
        }

        deviceService.ServiceId = service.Id;
        deviceService.Service = service;
        service.DeviceServices.Add(deviceService);
        return service;
    }
    #endregion

    #region [ Public Methods ]
    public static Service AddDeviceService(this Service service)
    {
        return service.AddDeviceService(DeviceServiceFactory.Create());
    }

    public static Service AddDeviceService(this Service service, string deviceInventoryId, string serviceId)
    {
        return service.AddDeviceService(DeviceServiceFactory.Create(deviceInventoryId, serviceId));
    }
    #endregion
}
