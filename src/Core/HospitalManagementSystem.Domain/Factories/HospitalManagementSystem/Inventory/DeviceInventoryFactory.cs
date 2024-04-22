namespace HospitalManagementSystem.Domain;

public static class DeviceInventoryFactory
{
    public static DeviceInventory Create()
    {
        return new DeviceInventory();
    }
    public static DeviceInventory Create(int currentAmount, string medicalDeviceId, string storageId)
    {
        return new DeviceInventory()
        {
            CurrentAmount = currentAmount,
            MedicalDeviceId = medicalDeviceId,
            StorageId = storageId
        };
    }
}
