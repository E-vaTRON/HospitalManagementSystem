namespace HospitalManagementSystem.Application;

public record OutputReferralDoctorDTO : ReferralDoctorDTO
{
    public ReferralDTO?             ReferralDTO             { get; init; }
    public AssignmentHistoryDTO?    AssignmentHistoryDTO    { get; init; }
}