namespace HospitalManagementSystem.Domain;

public class AssignmentHistory : EntityBase
{
    public string? AssignmentStatus { get; set; }

    public string?              MedicalExamEposodeId    { get; set; }
    public MedicalExamEposode   MedicalExamEposode      { get; set; } = default!; 
    public string?              DoctorId                { get; set; }
    public Doctor               Doctor                  { get; set; } = default!;
}
