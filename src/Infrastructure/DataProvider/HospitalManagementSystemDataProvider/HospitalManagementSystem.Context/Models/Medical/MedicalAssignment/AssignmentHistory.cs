namespace HospitalManagementSystem.DataProvider;

public class AssignmentHistory : ModelBase
{
    public string? AssignmentStatus { get; set; }

    public string?              MedicalExamEposodeId    { get; set; }
    public MedicalExamEposode   MedicalExamEposode      { get; set; } = default!;
}
