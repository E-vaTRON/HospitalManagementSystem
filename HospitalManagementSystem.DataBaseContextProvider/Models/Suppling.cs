namespace HospitalManagementSystem.DataBaseContextProvider;

public class Suppling : BaseModel<Guid>
{
    public int      ShipmentID      { get; set; }
    public int      InventoryID     { get; set; }
    public int      DrugID          { get; set; }
    public string   GooodName       { get; set; } = string.Empty;
    public int      Amount          { get; set; }

    public Inventory?           Inventory           { get; set; }
    public GoodsImportation?    GoodsImportation    { get; set; }
    public Drug?                Drug                { get; set; }

}
