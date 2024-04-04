namespace HospitalManagementSystem.Domain;

public class DrugInventory : EntityBase
{
    public int  CurrentAmount   { get; set; }       //số lượng hiện tại

    public string?      StorageId       { get; set; }       //mã kho
    public Storage      Storage         { get; set; } = default!;
    public string?      GoodSupplingId  { get; set; } = default!;
    public GoodSuppling GoodSuppling    { get; set; } = default!;

    public virtual ICollection<DrugPrescription> DrugPrescriptions { get; set; } = new HashSet<DrugPrescription>();
}
