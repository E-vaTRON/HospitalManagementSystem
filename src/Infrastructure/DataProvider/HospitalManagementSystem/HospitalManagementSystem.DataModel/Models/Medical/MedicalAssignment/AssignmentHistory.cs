namespace HospitalManagementSystem.DataProvider;

public class AssignmentHistory : ModelBase
{
    public string? AssignmentStatus { get; set; }

    public string?  DoctorId    { get; set; } // User Id Role<Doctor>

    public Guid?                MedicalExamEposodeId    { get; set; }
    public MedicalExamEposode   MedicalExamEposode      { get; set; } = default!;
    public Guid?                ReferralDoctorId        { get; set; }
    public ReferralDoctor?      ReferralDoctor          { get; set; }
}
