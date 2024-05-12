namespace HospitalManagementSystem.Application;

public class AssignmentHistoryDTO : DTOBase
{
    public string? AssignmentStatus { get; set; }

    public string?  DoctorId    { get; set; } // User Id Role<Doctor>

    public MedicalExamEpisodeDTO    MedicalExamEpisodeDTO   { get; set; } = default!; 
    public ReferralDoctorDTO?       ReferralDoctorDTO       { get; set; }
}
