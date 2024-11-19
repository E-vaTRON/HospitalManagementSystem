namespace HospitalManagementSystem.Domain;

public static class DrugInventoryExtensions
{
    #region [ Private Methods ]
    private static DrugInventory AddDrugPrescription(this DrugInventory drugInventory, DrugPrescription drugPrescription)
    {
        ArgumentException.ThrowIfNullOrEmpty(nameof(drugPrescription));

        if (drugInventory.DrugPrescriptions.Any(x => x.Id == drugPrescription.Id))
        {
            return drugInventory;
        }

        drugPrescription.DrugInventoryId = drugInventory.Id;
        drugPrescription.DrugInventory = drugInventory;
        drugInventory.DrugPrescriptions.Add(drugPrescription);
        return drugInventory;
    }
    #endregion

    #region [ Public Methods ]
    public static DrugInventory AddDrugPrescription(this DrugInventory drugInventory)
    {
        return drugInventory.AddDrugPrescription(DrugPrescriptionFactory.Create());
    }

    public static DrugInventory RemoveRelated(this DrugInventory drugInventory)
    {
        drugInventory.Drug = null!;
        drugInventory.Importation = null!;
        drugInventory.Storage = null!;
        drugInventory.DrugPrescriptions.Clear();
        return drugInventory;
    }
    #endregion
}
