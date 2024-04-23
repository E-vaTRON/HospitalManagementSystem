namespace HospitalManagementSystem.DataProvider;

public class DrugPrescription : ModelBase
{
    public Guid?                MedicalExamEposodeId    { get; set; }
    public MedicalExamEposode   MedicalExamEposode      { get; set; } = default!;
    public Guid?                DrugInventoryId         { get; set; }
    public DrugInventory        DrugInventory           { get; set; } = default!;
}