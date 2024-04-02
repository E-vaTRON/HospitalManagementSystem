namespace HospitalManagementSystem.Domain;

public class DrugDetail : EntityBase
{
    public string?              MedicalExamEposodeId    { get; set; }
    public MedicalExamEposode   MedicalExamEposode      { get; set; } = default!;
    public string?              DrugInventoryId         { get; set; }
    public DrugInventory        DrugInventory           { get; set; } = default!;
}