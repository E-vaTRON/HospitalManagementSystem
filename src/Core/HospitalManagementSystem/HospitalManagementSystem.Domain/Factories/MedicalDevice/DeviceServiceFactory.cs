namespace HospitalManagementSystem.Domain;

public static class DeviceServiceFactory
{
    public static DeviceService Create()
    {
        return new DeviceService();
    }

    public static DeviceService Create(string deviceInventoryId, string serviceId)
    {
        return new DeviceService()
        {
            DeviceInventoryId = deviceInventoryId,
            ServiceId = serviceId
        };
    }
}