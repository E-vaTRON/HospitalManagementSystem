namespace HospitalManagementSystem.DataProvider;

public class DrugInventory : ModelBase
{
    public int      CurrentAmount        { get; set; }       //số lượng hiện tại

    public string?      StorageId       { get; set; }       //mã kho
    public Storage      Storage         { get; set; } = default!;
    public string?      GoodSupplingId  { get; set; }
    public GoodSuppling GoodSuppling    { get; set; } = default!;

    public virtual ICollection<DrugDetail> DrugBillDetails { get; set; } = new HashSet<DrugDetail>();
}
