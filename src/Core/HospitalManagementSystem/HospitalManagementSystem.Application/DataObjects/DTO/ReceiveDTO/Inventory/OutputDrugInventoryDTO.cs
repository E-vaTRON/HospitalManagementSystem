namespace HospitalManagementSystem.Application;

public record OutputDrugInventoryDTO : DrugInventoryDTO
{
    public OutputStorageDTO?          Storage          { get; init; }
    //public OutputGoodSupplingDTO?     GoodSuppling     { get; init; }
    public OutputImportationDTO?      Importation      { get; init; }
    public OutputDrugDTO?             Drug             { get; init; }

    public virtual ICollection<OutputDrugPrescriptionDTO>? DrugPrescriptions { get; init; }
}