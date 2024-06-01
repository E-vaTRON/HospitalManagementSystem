namespace HospitalManagementSystem.Application;

public record OutputAssignmentHistoryDTO : AssignmentHistoryDTO
{
    public OutputMedicalExamEpisodeDTO?   MedicalExamEpisodeDTO   { get; init; }
    public OutputReferralDoctorDTO?       ReferralDoctorDTO       { get; init; }
}