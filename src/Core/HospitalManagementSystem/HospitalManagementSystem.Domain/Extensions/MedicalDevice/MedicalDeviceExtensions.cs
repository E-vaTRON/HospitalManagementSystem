namespace HospitalManagementSystem.Domain;

public static class MedicalDeviceExtensions
{
    #region [ Private Methods ]
    private static MedicalDevice AddDeviceInventory(this MedicalDevice medicalDevice, DeviceInventory deviceInventory)
    {
        ArgumentException.ThrowIfNullOrEmpty(nameof(deviceInventory));

        // Assuming MedicalDeviceId and StorageId together should be unique
        if (medicalDevice.DeviceInventorys.Any(x => x.MedicalDeviceId == deviceInventory.Id))
        {
            return medicalDevice;
        }

        deviceInventory.MedicalDeviceId = medicalDevice.Id;
        deviceInventory.MedicalDevice = medicalDevice;
        medicalDevice.DeviceInventorys.Add(deviceInventory);
        return medicalDevice;
    }
    #endregion

    #region [ Public Methods ]
    public static MedicalDevice AddDeviceInventory(this MedicalDevice medicalDevice)
    {
        return medicalDevice.AddDeviceInventory(DeviceInventoryFactory.Create());
    }

    public static MedicalDevice AddDeviceInventory(this MedicalDevice medicalDevice, int currentAmount, string medicalDeviceId, string storageId)
    {
        return medicalDevice.AddDeviceInventory(DeviceInventoryFactory.Create(currentAmount, medicalDeviceId, storageId));
    }
    #endregion
}
