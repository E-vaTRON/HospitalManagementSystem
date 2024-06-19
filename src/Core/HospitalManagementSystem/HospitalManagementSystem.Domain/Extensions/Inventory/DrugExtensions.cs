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
    #endregion

    #region [ Public Methods ]
    public static Drug AddDrugInventory(this Drug drug)
    {
        return drug.AddDrugInventory(DrugInventoryFactory.Create());
    }

    public static Drug AddDrugInventory(this Drug drug, string goodInformation, DateTime expiryDate, int orinaryAmount, string importationId, string drugId)
    {
        return drug.AddDrugInventory(DrugInventoryFactory.Create(goodInformation, expiryDate, orinaryAmount, importationId, drugId));
    }

    public static Drug AddDrugInventory(this Drug drug, int currentAmount, string goodInformation, DateTime expiryDate, int orinaryAmount, string importationId, string drugId, string storageId)
    {
        return drug.AddDrugInventory(DrugInventoryFactory.Create(currentAmount, goodInformation, expiryDate, orinaryAmount, importationId, drugId, storageId));
    }
    #endregion
}
