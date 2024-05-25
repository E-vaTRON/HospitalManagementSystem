namespace HospitalManagementSystem.Application;

public record InputAssignmentHistoryDTO : AssignmentHistoryDTO
{
    public string? MedicalExamEpisodeDTOId  { get; init; }
    public string? ReferralDoctorDTOId      { get; init; }
}
