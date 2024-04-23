namespace HospitalManagementSystem.Domain;

public static class GoodSupplingFactory
{
    public static GoodSuppling Create()
    {
        return new GoodSuppling();
    }

    public static GoodSuppling Create(string goodInformation, DateTime expiryDate, int orinaryAmount, string inventoryId, string importationId, string drugId)
    {
        return new GoodSuppling()
        {
            GoodInformation = goodInformation,
            ExpiryDate = expiryDate,
            OrinaryAmount = orinaryAmount,
            InventoryId = inventoryId,
            ImportationId = importationId,
            DrugId = drugId
        };
    }
}
