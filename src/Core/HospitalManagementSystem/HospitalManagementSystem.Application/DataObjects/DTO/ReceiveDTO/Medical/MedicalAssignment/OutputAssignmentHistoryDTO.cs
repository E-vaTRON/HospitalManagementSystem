namespace HospitalManagementSystem.Application;

public record OutputAssignmentHistoryDTO : AssignmentHistoryDTO
{
    public MedicalExamEpisodeDTO?   MedicalExamEpisodeDTO   { get; init; }
    public ReferralDoctorDTO?       ReferralDoctorDTO       { get; init; }
}