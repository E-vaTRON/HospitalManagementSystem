namespace HospitalManagementSystem.Application;

public record OutputDrugPrescriptionDTO : DrugPrescriptionDTO
{
    public OutputMedicalExamEpisodeDTO?   MedicalExamEpisode   { get; init; }
    public OutputDrugInventoryDTO?        DrugInventory        { get; init; }
}