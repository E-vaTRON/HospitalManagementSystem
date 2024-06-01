namespace HospitalManagementSystem.Domain;

public static class DrugInventoryFactory
{
    public static DrugInventory Create()
    {
        return new DrugInventory();
    }

    public static DrugInventory Create(int currentAmount, string goodInformation, DateTime expiryDate, int orinaryAmount, string importationId, string drugId, string storageId)
    {
        return new DrugInventory()
        {
            CurrentAmount = currentAmount,
            StorageId = storageId,
            GoodInformation = goodInformation,
            ExpiryDate = expiryDate,
            OrinaryAmount = orinaryAmount,
            ImportationId = importationId,
            DrugId = drugId
        };
    }

    public static DrugInventory Create(string goodInformation, DateTime expiryDate, int orinaryAmount, string importationId, string drugId)
    {
        return new DrugInventory()
        {
            GoodInformation = goodInformation,
            ExpiryDate = expiryDate,
            OrinaryAmount = orinaryAmount,
            ImportationId = importationId,
            DrugId = drugId
        };
    }
}
