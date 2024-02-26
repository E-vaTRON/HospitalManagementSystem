namespace HospitalManagementSystem.DataProvider;

public class GoodSuppling : ModelBase
{
    public string   GoodInformation { get; set; } = string.Empty;
    public DateTime ExpiryDate      { get; set; }       //hạng dùng
    public int      OrinaryAmount   { get; set; }

    public string?          InventoryId     { get; set; }
    public DrugInventory?   Inventory       { get; set; }
    public string?          ImportationId   { get; set; }
    public Importation?     Importation     { get; set; }
    public string?          DrugId          { get; set; }
    public Drug?            Drug            { get; set; }

}
