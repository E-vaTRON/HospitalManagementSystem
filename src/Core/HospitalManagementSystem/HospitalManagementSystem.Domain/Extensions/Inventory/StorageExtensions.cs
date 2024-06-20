namespace HospitalManagementSystem.Domain;

public static class StorageExtensions
{
    #region [ Private Methods ]
    private static Storage AddDrugInventory(this Storage storage, DrugInventory drugInventory)
    {
        ArgumentException.ThrowIfNullOrEmpty(nameof(drugInventory));

        if (storage.DrugInventories.Any(x => x.Id == drugInventory.Id))
        {
            return storage;
        }

        drugInventory.StorageId = storage.Id;
        drugInventory.Storage = storage;
        storage.DrugInventories.Add(drugInventory);
        return storage;
    }

    private static Storage AddDeviceInventory(this Storage storage, DeviceInventory deviceInventory)
    {
        ArgumentException.ThrowIfNullOrEmpty(nameof(deviceInventory));

        if (storage.DrugInventories.Any(x => x.Id == deviceInventory.Id))
        {
            return storage;
        }

        deviceInventory.StorageId = storage.Id;
        deviceInventory.Storage = storage;
        storage.DeviceInventories.Add(deviceInventory);
        return storage;
    }

    private static Storage AddDeviceInventory(this Storage storage, MedicalDevice medicalDevice, DeviceInventory deviceInventory)
    {
        ArgumentException.ThrowIfNullOrEmpty(nameof(deviceInventory));

        if (storage.DrugInventories.Any(x => x.Id == deviceInventory.Id))
        {
            return storage;
        }

        deviceInventory.StorageId = storage.Id;
        deviceInventory.Storage = storage;
        deviceInventory.MedicalDeviceId = medicalDevice.Id;
        deviceInventory.MedicalDevice = medicalDevice;
        medicalDevice.DeviceInventories.Add(deviceInventory);
        storage.DeviceInventories.Add(deviceInventory);
        return storage;
    }
    #endregion

    #region [ Public Methods ]
    public static Storage AddDrugInventory(this Storage storage)
    {
        return storage.AddDrugInventory(DrugInventoryFactory.Create());
    }

    public static Storage AddDrugInventory(this Storage storage, string goodInformation, DateTime expiryDate, int orinaryAmount, string importationId, string drugId)
    {
        return storage.AddDrugInventory(DrugInventoryFactory.Create(goodInformation, expiryDate, orinaryAmount, importationId, drugId));
    }

    public static Storage AddDrugInventory(this Storage storage, int currentAmount, string goodInformation, DateTime expiryDate, int orinaryAmount, string importationId, string drugId, string storageId)
    {
        return storage.AddDrugInventory(DrugInventoryFactory.Create(currentAmount, goodInformation, expiryDate, orinaryAmount, importationId, drugId, storageId));
    }

    public static Storage AddDeviceInventory(this Storage storage)
    {
        return storage.AddDeviceInventory(DeviceInventoryFactory.Create());
    }

    public static Storage AddDeviceInventory(this Storage storage, int currentAmount, string medicalDeviceId, string storageId)
    {
        return storage.AddDeviceInventory(DeviceInventoryFactory.Create(currentAmount, medicalDeviceId, storageId));
    }
    #endregion
}
