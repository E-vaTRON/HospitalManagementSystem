namespace HospitalManagementSystem.Domain;

public static class DrugInventoryFactory
{
    public static DrugInventory Create()
    {
        return new DrugInventory();
    }

    public static DrugInventory Create(int currentAmount, string goodInformation, DateTime expiryDate, int orinaryAmount)
    {
        return new DrugInventory()
        {
            CurrentAmount = currentAmount,
            GoodInformation = goodInformation,
            ExpiryDate = expiryDate,
            OrinaryAmount = orinaryAmount
        };
    }

    public static DrugInventory Create(string goodInformation, DateTime expiryDate, int orinaryAmount)
    {
        return new DrugInventory()
        {
            GoodInformation = goodInformation,
            ExpiryDate = expiryDate,
            OrinaryAmount = orinaryAmount
        };
    }
}
