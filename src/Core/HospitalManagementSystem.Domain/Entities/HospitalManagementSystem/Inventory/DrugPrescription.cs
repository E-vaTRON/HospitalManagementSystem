namespace HospitalManagementSystem.Domain;

public class DrugPrescription : EntityBase
{
    public string?              MedicalExamEposodeId    { get; set; }
    public MedicalExamEposode   MedicalExamEposode      { get; set; } = default!;
    public string?              DrugInventoryId         { get; set; }
    public DrugInventory        DrugInventory           { get; set; } = default!;
}