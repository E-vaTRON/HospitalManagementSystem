namespace HospitalManagementSystem.Domain;

public class AssignmentHistory : EntityBase
{
    public string? AssignmentStatus { get; set; }

    public string?  DoctorId    { get; set; } // User Id Role<Doctor>

    public string?              MedicalExamEpisodeId    { get; set; }
    public MedicalExamEpisode   MedicalExamEpisode      { get; set; } = default!; 
    public string?              ReferralDoctorId        { get; set; }
    public ReferralDoctor?      ReferralDoctor          { get; set; }
}
