namespace HospitalManagementSystem.Application;

public record OutputDrugPrescriptionDTO : DrugPrescriptionDTO
{
    public OutputMedicalExamEpisodeDTO?   MedicalExamEpisodeDTO   { get; init; }
    public OutputDrugInventoryDTO?        DrugInventoryDTO        { get; init; }
}