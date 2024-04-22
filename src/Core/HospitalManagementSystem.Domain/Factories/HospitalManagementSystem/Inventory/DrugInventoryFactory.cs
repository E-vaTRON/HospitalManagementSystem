namespace HospitalManagementSystem.Domain;

public static class DrugInventoryFactory
{
    public static DrugInventory Create()
    {
        return new DrugInventory();
    }

    public static DrugInventory Create(int currentAmount, string storageId, string goodSupplingId)
    {
        return new DrugInventory()
        {
            CurrentAmount = currentAmount,
            StorageId = storageId,
            GoodSupplingId = goodSupplingId
        };
    }
}
