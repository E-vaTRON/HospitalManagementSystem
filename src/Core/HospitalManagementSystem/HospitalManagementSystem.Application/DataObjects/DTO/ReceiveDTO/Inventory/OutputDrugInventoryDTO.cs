namespace HospitalManagementSystem.Application;

public record OutputDrugInventoryDTO : DrugInventoryDTO
{
    public OutputStorageDTO?          StorageDTO          { get; init; }
    public OutputGoodSupplingDTO?     GoodSupplingDTO     { get; init; }
    public OutputDrugInventoryDTO?    InventoryDTO        { get; init; }
    public OutputImportationDTO?      ImportationDTO      { get; init; }
    public OutputDrugDTO?             DrugDTO             { get; init; }

    public virtual ICollection<OutputDrugPrescriptionDTO>? DrugPrescriptionDTOs { get; init; }
}