namespace HospitalManagementSystem.Domain;

public class DrugInventory : EntityBase
{
    public string   GoodInformation { get; set; } = string.Empty;
    public DateTime ExpiryDate      { get; set; }       //hạng dùng
    public int      OrinaryAmount   { get; set; }
    public int      CurrentAmount   { get; set; }       //số lượng hiện tại

    public string?          StorageId       { get; set; }       //mã kho
    public Storage          Storage         { get; set; } = default!;
    public string?          ImportationId   { get; set; }
    public Importation?     Importation     { get; set; }
    public string?          DrugId          { get; set; }
    public Drug?            Drug            { get; set; }

    public virtual ICollection<DrugPrescription> DrugPrescriptions { get; set; } = new HashSet<DrugPrescription>();
}
