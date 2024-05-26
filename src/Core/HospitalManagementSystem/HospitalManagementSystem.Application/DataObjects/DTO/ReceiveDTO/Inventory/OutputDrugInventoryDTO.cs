namespace HospitalManagementSystem.Application;

public record OutputDrugInventoryDTO : DrugInventoryDTO
{
    public StorageDTO?      StorageDTO      { get; init; }
    public GoodSupplingDTO? GoodSupplingDTO { get; init; }

    public virtual ICollection<DrugPrescriptionDTO>? DrugPrescriptionDTOs { get; init; }
}