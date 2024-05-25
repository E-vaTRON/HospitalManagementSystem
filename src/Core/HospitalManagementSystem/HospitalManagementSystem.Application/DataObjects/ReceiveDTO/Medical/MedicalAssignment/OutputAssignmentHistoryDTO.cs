namespace HospitalManagementSystem.Application;

public record OutputAssignmentHistoryDTO : AssignmentHistoryDTO
{
    public MedicalExamEpisodeDTO?   MedicalExamEpisodeDTO   { get; set; }
    public ReferralDoctorDTO?       ReferralDoctorDTO       { get; set; }
}