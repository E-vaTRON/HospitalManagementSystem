namespace HospitalManagementSystem.Domain;

public class Bill : EntityBase
{
    public int      TransactionID   { get; set; }
    public int      InventoryID     { get; set; }
    public int      DrugID          { get; set; }
    public string   DrugName        { get; set; } = string.Empty;
    public int      Amount          { get; set; }

    public PatientTransactionHistory?   Transaction     { get; set; }
    public Inventory?                   Inventory       { get; set; }
    public Drug?                        Drug            { get; set; }

}
