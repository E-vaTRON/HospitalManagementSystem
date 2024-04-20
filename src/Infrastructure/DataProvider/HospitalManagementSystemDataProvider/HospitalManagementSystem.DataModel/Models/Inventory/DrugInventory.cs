namespace HospitalManagementSystem.DataProvider;

public class DrugInventory : ModelBase
{
    public int      CurrentAmount        { get; set; }       //số lượng hiện tại

    public Guid?        StorageId       { get; set; }       //mã kho
    public Storage      Storage         { get; set; } = default!;
    public Guid?        GoodSupplingId  { get; set; }
    public GoodSuppling GoodSuppling    { get; set; } = default!;

    public virtual ICollection<DrugPrescription> DrugPrescriptions { get; set; } = new HashSet<DrugPrescription>();
}
