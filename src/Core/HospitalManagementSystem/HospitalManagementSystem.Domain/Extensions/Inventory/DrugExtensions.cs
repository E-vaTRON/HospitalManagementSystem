namespace HospitalManagementSystem.Domain;

public static class DrugExtensions
{
    #region [ Private Methods ]
    private static Drug AddDrugInventory(this Drug drug, DrugInventory drugInventory)
    {
        ArgumentException.ThrowIfNullOrEmpty(nameof(drugInventory));

        if (drug.DrugInventories.Any(x => x.Id == drugInventory.Id))
        {
            return drug;
        }

        drugInventory.DrugId = drug.Id;
        drugInventory.Drug = drug;
        drug.DrugInventories.Add(drugInventory);
        return drug;
    }

    private static Drug AddToStorage(this Drug drug, Storage storage, Importation importation, DrugInventory drugInventory)
    {
        ArgumentException.ThrowIfNullOrEmpty(nameof(drugInventory));

        drugInventory.DrugId = drug.Id; 
        drugInventory.Drug = drug;
        drugInventory.StorageId = storage.Id;
        drugInventory.Storage = storage;
        drugInventory.ImportationId = importation.Id;
        drugInventory.Importation = importation;
        importation.DrugInventories.Add(drugInventory);
        drug.DrugInventories.Add(drugInventory);
        storage.DrugInventories.Add(drugInventory);
        return drug;
    }
    #endregion

    #region [ Public Methods ]
    public static Drug AddDrugInventory(this Drug drug)
    {
        return drug.AddDrugInventory(DrugInventoryFactory.Create());
    }

    public static Drug AddToStorage(this Drug drug, Storage storage, Importation importation)
    {
        return drug.AddToStorage(storage, importation, DrugInventoryFactory.Create());
    }

    public static Drug AddDrugInventory(this Drug drug, string goodInformation, DateTime expiryDate, int orinaryAmount)
    {
        return drug.AddDrugInventory(DrugInventoryFactory.Create(goodInformation, expiryDate, orinaryAmount));
    }

    public static Drug AddToStorage(this Drug drug, Storage storage, Importation importation, string goodInformation, DateTime expiryDate, int orinaryAmount)
    {
        return drug.AddToStorage(storage, importation, DrugInventoryFactory.Create(goodInformation, expiryDate, orinaryAmount));
    }

    public static Drug AddDrugInventory(this Drug drug, int currentAmount, string goodInformation, DateTime expiryDate, int orinaryAmount)
    {
        return drug.AddDrugInventory(DrugInventoryFactory.Create(currentAmount, goodInformation, expiryDate, orinaryAmount));
    }

    public static Drug RemoveRelated(this Drug drug)
    {
        drug.DrugInventories.Clear();
        return drug;
    }
    #endregion
}
