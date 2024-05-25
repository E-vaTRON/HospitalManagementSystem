namespace HospitalManagementSystem.Application;

public record OutputDrugPrescriptionDTO : DrugPrescriptionDTO
{
    public MedicalExamEpisodeDTO?   MedicalExamEpisodeDTO   { get; set; }
    public DrugInventoryDTO?        DrugInventoryDTO        { get; set; }
}