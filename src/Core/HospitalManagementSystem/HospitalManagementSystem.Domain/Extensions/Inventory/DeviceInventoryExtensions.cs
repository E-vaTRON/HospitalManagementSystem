namespace HospitalManagementSystem.Domain;

public static class DeviceInventoryExtensions
{
    #region [ Private Methods ]
    private static DeviceInventory AddDeviceService(this DeviceInventory deviceInventory, DeviceService deviceService)
    {
        ArgumentException.ThrowIfNullOrEmpty(nameof(deviceService));

        if (deviceInventory.DeviceServices.Any(x => x.Id == deviceService.Id))
        {
            return deviceInventory;
        }

        deviceService.DeviceInventoryId = deviceInventory.Id;
        deviceService.DeviceInventory = deviceInventory;
        deviceInventory.DeviceServices.Add(deviceService);
        return deviceInventory;
    }
    #endregion

    #region [ Public Methods ]
    public static DeviceInventory AddDeviceService(this DeviceInventory deviceInventory)
    {
        return deviceInventory.AddDeviceService(DeviceServiceFactory.Create());
    }

    public static DeviceInventory AddDeviceService(this DeviceInventory deviceInventory, string deviceInventoryId, string serviceId)
    {
        return deviceInventory.AddDeviceService(DeviceServiceFactory.Create(deviceInventoryId, serviceId));
    }
    #endregion
}
