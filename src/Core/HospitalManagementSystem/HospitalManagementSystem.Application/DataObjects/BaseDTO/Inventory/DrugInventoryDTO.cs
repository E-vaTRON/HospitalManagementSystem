namespace HospitalManagementSystem.Application;

public class DrugInventoryDTO : DTOBase
{
    public int  CurrentAmount   { get; set; }       //số lượng hiện tại

    public StorageDTO       StorageDTO      { get; set; } = default!;
    public GoodSupplingDTO  GoodSupplingDTO { get; set; } = default!;

    public virtual ICollection<DrugPrescriptionDTO> DrugPrescriptions { get; set; } = new HashSet<DrugPrescriptionDTO>();
}
