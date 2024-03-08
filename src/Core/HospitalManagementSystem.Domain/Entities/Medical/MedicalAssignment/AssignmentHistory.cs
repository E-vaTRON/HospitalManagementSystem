namespace HospitalManagementSystem.Domain;

public class AssignmentHistory : EntityBase
{
    public string? AssignmentStatus { get; set; }

    public string?              MedicalExamEposodeId    { get; set; }
    public MedicalExamEposode   MedicalExamEposode      { get; set; } = default!;
}
