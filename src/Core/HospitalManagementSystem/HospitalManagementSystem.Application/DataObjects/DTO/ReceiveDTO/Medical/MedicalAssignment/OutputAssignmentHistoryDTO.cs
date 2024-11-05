namespace HospitalManagementSystem.Application;

public record OutputAssignmentHistoryDTO : AssignmentHistoryDTO
{
    public OutputMedicalExamEpisodeDTO?   MedicalExamEpisode   { get; init; }
    public OutputReferralDoctorDTO?       ReferralDoctor       { get; init; }
}