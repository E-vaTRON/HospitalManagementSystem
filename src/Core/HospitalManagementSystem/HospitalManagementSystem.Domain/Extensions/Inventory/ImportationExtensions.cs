﻿namespace HospitalManagementSystem.Domain;

public static class ImportationExtensions
{
    #region [ Private Methods ]
    private static Importation AddDrugInventory(this Importation importation, DrugInventory drugInventory)
    {
        ArgumentException.ThrowIfNullOrEmpty(nameof(drugInventory));

        if (importation.DrugInventories.Any(x => x.Id == drugInventory.Id))
        {
            return importation;
        }

        drugInventory.ImportationId = importation.Id;
        drugInventory.Importation = importation;
        importation.DrugInventories.Add(drugInventory);
        return importation;
    }
    #endregion

    #region [ Public Methods ]
    public static Importation AddDrugInventory(this Importation importation)
    {
        return importation.AddDrugInventory(DrugInventoryFactory.Create());
    } 

    public static Importation AddDrugInventory(this Importation importation, string goodInformation, DateTime expiryDate, int orinaryAmount)
    {
        return importation.AddDrugInventory(DrugInventoryFactory.Create(goodInformation, expiryDate, orinaryAmount));
    }

    public static Importation AddDrugInventory(this Importation importation, int currentAmount, string goodInformation, DateTime expiryDate, int orinaryAmount)
    {
        return importation.AddDrugInventory(DrugInventoryFactory.Create(currentAmount, goodInformation, expiryDate, orinaryAmount));
    }

    public static Importation RemoveRelated(this Importation importation)
    {
        importation.DrugInventories.Clear();
        return importation;
    }
    #endregion
}
