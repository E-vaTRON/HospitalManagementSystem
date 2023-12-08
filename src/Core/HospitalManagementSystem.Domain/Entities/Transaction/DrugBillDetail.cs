namespace HospitalManagementSystem.Domain;

public class DrugBillDetail : EntityBase
{
    public string?          BillId      { get; set; }
    public Bill             Bill        { get; set; } = default!;
    public string?          InventoryId { get; set; }
    public DrugInventory    Inventory   { get; set; } = default!;
}