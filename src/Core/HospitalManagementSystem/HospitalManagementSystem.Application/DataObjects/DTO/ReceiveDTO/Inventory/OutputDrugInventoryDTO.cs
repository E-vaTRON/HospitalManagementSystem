namespace HospitalManagementSystem.Application;

public record OutputDrugInventoryDTO : DrugInventoryDTO
{
    public StorageDTO?          StorageDTO          { get; init; }
    public GoodSupplingDTO?     GoodSupplingDTO     { get; init; }
    public DrugInventoryDTO?    InventoryDTO        { get; init; }
    public ImportationDTO?      ImportationDTO      { get; init; }
    public DrugDTO?             DrugDTO             { get; init; }

    public virtual ICollection<DrugPrescriptionDTO>? DrugPrescriptionDTOs { get; init; }
}