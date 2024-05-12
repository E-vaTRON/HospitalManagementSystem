namespace HospitalManagementSystem.Application;

public class DrugPrescriptionDTO : DTOBase
{
    public MedicalExamEpisodeDTO    MedicalExamEpisodeDTO   { get; set; } = default!;
    public DrugInventoryDTO         DrugInventoryDTO        { get; set; } = default!;
}