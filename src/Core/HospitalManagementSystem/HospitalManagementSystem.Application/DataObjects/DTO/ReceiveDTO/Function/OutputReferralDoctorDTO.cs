namespace HospitalManagementSystem.Application;

public record OutputReferralDoctorDTO : ReferralDoctorDTO
{
    public OutputReferralDTO?             ReferralDTO             { get; init; }
    public OutputAssignmentHistoryDTO?    AssignmentHistoryDTO    { get; init; }
}