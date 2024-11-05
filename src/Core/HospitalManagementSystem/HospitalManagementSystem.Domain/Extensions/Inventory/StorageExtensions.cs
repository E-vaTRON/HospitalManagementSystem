namespace HospitalManagementSystem.Domain;

public static class StorageExtensions
{
    #region [ Private Methods ]
    private static Storage AddDrugInventory(this Storage storage, Drug drug, DrugInventory drugInventory)
    {
        ArgumentException.ThrowIfNullOrEmpty(nameof(drugInventory));

        if (storage.DrugInventories.Any(x => x.Id == drugInventory.Id))
        {
            return storage;
        }

        drugInventory.StorageId = storage.Id;
        drugInventory.Storage = storage;
        drugInventory.DrugId = drug.Id;
        drugInventory.Drug = drug;
        drug.DrugInventories.Add(drugInventory);
        storage.DrugInventories.Add(drugInventory);
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
    public static Storage RemoveRelated(this Storage storage)
    {
        storage.DeviceInventories.Clear();
        storage.DrugInventories.Clear();
        return storage;
    }
    #endregion
}
