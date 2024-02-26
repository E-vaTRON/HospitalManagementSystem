namespace HospitalManagementSystem.DataProvider;

public class DrugBillDetail : ModelBase
{
    public string?          BillId      { get; set; }
    public Bill             Bill        { get; set; } = default!;
    public string?          InventoryId { get; set; }
    public DrugInventory    Inventory   { get; set; } = default!;
}