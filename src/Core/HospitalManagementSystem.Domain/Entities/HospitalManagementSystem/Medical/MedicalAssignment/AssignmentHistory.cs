namespace HospitalManagementSystem.Domain;

public class AssignmentHistory : EntityBase
{
    public string? AssignmentStatus { get; set; }

    public string?  DoctorId    { get; set; } // User Id Role<Doctor>

    public string?              MedicalExamEposodeId    { get; set; }
    public MedicalExamEposode   MedicalExamEposode      { get; set; } = default!; 
    public string?              ReferralDoctorId        { get; set; }
    public ReferralDoctor?      ReferralDoctor          { get; set; }
}
