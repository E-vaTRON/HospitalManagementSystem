namespace HospitalManagementSystem.DataProvider;

public class DrugInventory : ModelBase
{
    public int  CurrentAmount   { get; set; }       //số lượng hiện tại

    public string?  DrugId      { get; set; }        //mã hàng
    public Drug     Drug        { get; set; } = default!;
    public string?  StorageId   { get; set; }       //mã kho
    public Storage  Storage     { get; set; } = default!;

    public virtual ICollection<GoodSuppling>    GoodSupplings   { get; set; } = new HashSet<GoodSuppling>();
    public virtual ICollection<Bill>            Bills           { get; set; } = new HashSet<Bill>();
}
