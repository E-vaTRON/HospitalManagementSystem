namespace HospitalManagementSystem.Application;

public record OutputReferralDoctorDTO : ReferralDoctorDTO
{
    public OutputReferralDTO?             Referral             { get; init; }
    public OutputAssignmentHistoryDTO?    AssignmentHistory    { get; init; }
}