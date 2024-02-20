namespace HospitalManagementSystem.DataBaseContextProvider;

public class DrugInventory : ModelBase
{
    public DateTime     ExpiryDate      { get; set; }       //hạng dùng
    public int          CurrentAmount   { get; set; }       //số lượng hiện tại
    public int          OrinaryAmount   { get; set; }

    public string?  DrugID     { get; set; }       //mã hàng
    public Drug     Drug        { get; set; } = default!;
    public string?  StorageID   { get; set; }       //mã kho
    public Storage  Storage     { get; set; } = default!;

    public virtual ICollection<Suppling>    Supplings   { get; set; } = new HashSet<Suppling>();
    public virtual ICollection<Bill>        Bills       { get; set; } = new HashSet<Bill>();
}
