namespace HospitalManagementSystem.Application;

public record OutputDrugPrescriptionDTO : DrugPrescriptionDTO
{
    public MedicalExamEpisodeDTO?   MedicalExamEpisodeDTO   { get; init; }
    public DrugInventoryDTO?        DrugInventoryDTO        { get; init; }
}