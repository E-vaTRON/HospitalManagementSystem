namespace HospitalManagementSystem.DataProvider;

public class AssignmentHistory : ModelBase
{
    public string? AssignmentStatus { get; set; }

    public string?  DoctorId    { get; set; } // User Id Role<Doctor>

    public Guid?                MedicalExamEpisodeId    { get; set; }
    public MedicalExamEpisode   MedicalExamEpisode      { get; set; } = default!;
    public Guid?                ReferralDoctorId        { get; set; }
    public ReferralDoctor?      ReferralDoctor          { get; set; }
}
