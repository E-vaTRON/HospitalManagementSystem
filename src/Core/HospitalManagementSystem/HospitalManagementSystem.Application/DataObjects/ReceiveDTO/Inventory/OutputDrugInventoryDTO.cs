namespace HospitalManagementSystem.Application;

public record OutputDrugInventoryDTO : DrugInventoryDTO
{
    public StorageDTO?      StorageDTO      { get; set; }
    public GoodSupplingDTO? GoodSupplingDTO { get; set; }

    public virtual ICollection<DrugPrescriptionDTO>? DrugPrescriptionDTOs { get; init; }
}