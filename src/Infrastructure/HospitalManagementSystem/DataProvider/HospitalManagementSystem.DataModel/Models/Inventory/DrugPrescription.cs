namespace HospitalManagementSystem.DataProvider;

public class DrugPrescription : ModelBase
{
    public int Amount { get; set; }

    public Guid?                MedicalExamEposodeId    { get; set; }
    public MedicalExamEpisode   MedicalExamEposode      { get; set; } = default!;
    public Guid?                DrugInventoryId         { get; set; }
    public DrugInventory        DrugInventory           { get; set; } = default!;
}