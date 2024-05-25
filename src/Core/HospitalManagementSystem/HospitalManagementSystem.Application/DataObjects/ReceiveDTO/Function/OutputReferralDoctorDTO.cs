namespace HospitalManagementSystem.Application;

public record OutputReferralDoctorDTO : ReferralDoctorDTO
{
    public ReferralDTO?             ReferralDTO             { get; set; }
    public AssignmentHistoryDTO?    AssignmentHistoryDTO    { get; set; }
}