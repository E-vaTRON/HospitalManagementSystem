namespace HospitalManagementSystem.Domain;

public class DrugPrescription : EntityBase
{
    public int Amount { get; set; }

    public string?              MedicalExamEpisodeId    { get; set; }
    public MedicalExamEpisode   MedicalExamEpisode      { get; set; } = default!;
    public string?              DrugInventoryId         { get; set; }
    public DrugInventory        DrugInventory           { get; set; } = default!;
}