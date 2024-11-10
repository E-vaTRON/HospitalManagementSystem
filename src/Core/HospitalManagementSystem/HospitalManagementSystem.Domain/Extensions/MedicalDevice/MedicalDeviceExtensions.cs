namespace HospitalManagementSystem.Domain;

public static class MedicalDeviceExtensions
{
    #region [ Private Methods ]
    private static MedicalDevice AddDeviceUnit(this MedicalDevice medicalDevice, MeasurementUnit measurementUnit, DeviceUnit deviceUnit)
    {
        ArgumentException.ThrowIfNullOrEmpty(nameof(measurementUnit));
        ArgumentException.ThrowIfNullOrEmpty(nameof(deviceUnit));

        if (medicalDevice.DeviceUnits.Any(x => x.Id == measurementUnit.Id))
        {
            return medicalDevice;
        }

        deviceUnit.MedicalDeviceId = medicalDevice.Id;
        deviceUnit.MedicalDevice = medicalDevice;
        deviceUnit.MeasurementUnitId = measurementUnit.Id;
        deviceUnit.MeasurementUnit = measurementUnit;
        medicalDevice.DeviceUnits.Add(deviceUnit);
        measurementUnit.DeviceUnits.Add(deviceUnit);
        return medicalDevice;
    }

    private static MedicalDevice AddDeviceInventory(this MedicalDevice medicalDevice, DeviceInventory deviceInventory)
    {
        ArgumentException.ThrowIfNullOrEmpty(nameof(deviceInventory));

        if (medicalDevice.DeviceInventories.Any(x => x.MedicalDeviceId == deviceInventory.Id))
        {
            return medicalDevice;
        }

        deviceInventory.MedicalDeviceId = medicalDevice.Id;
        deviceInventory.MedicalDevice = medicalDevice;
        medicalDevice.DeviceInventories.Add(deviceInventory);
        return medicalDevice;
    }

    private static MedicalDevice AddToStorage(this MedicalDevice medicalDevice, Storage storage, DeviceInventory deviceInventory)
    {
        ArgumentException.ThrowIfNullOrEmpty(nameof(deviceInventory));
        ArgumentException.ThrowIfNullOrEmpty(nameof(storage));

        if (medicalDevice.DeviceInventories.Any(x => x.MedicalDeviceId == deviceInventory.Id))
        {
            return medicalDevice;
        }

        deviceInventory.MedicalDeviceId = medicalDevice.Id;
        deviceInventory.MedicalDevice = medicalDevice;
        deviceInventory.StorageId = storage.Id;
        deviceInventory.Storage = storage;
        medicalDevice.DeviceInventories.Add(deviceInventory);
        storage.DeviceInventories.Add(deviceInventory);
        return medicalDevice;
    }
    #endregion

    #region [ Public Methods ]
    public static MedicalDevice AddDeviceUnit(this MedicalDevice medicalDevice, MeasurementUnit measurementUnit)
    {
        return medicalDevice.AddDeviceUnit(measurementUnit, DeviceUnitFactory.Create());
    }

    public static MedicalDevice AddDeviceInventory(this MedicalDevice medicalDevice)
    {
        return medicalDevice.AddDeviceInventory(DeviceInventoryFactory.Create());
    }

    public static MedicalDevice AddToStorage(this MedicalDevice medicalDevice, Storage storage)
    {
        return medicalDevice.AddToStorage(storage, DeviceInventoryFactory.Create());
    }

    public static MedicalDevice AddDeviceInventory(this MedicalDevice medicalDevice, int currentAmount, string medicalDeviceId, string storageId)
    {
        return medicalDevice.AddDeviceInventory(DeviceInventoryFactory.Create(currentAmount, medicalDeviceId, storageId));
    }

    public static MedicalDevice RemoveRelated(this MedicalDevice medicalDevice)
    {
        medicalDevice.DeviceInventories.Clear();
        medicalDevice.MedicalDeviceForms.Clear();
        return medicalDevice;
    }
    #endregion
}
