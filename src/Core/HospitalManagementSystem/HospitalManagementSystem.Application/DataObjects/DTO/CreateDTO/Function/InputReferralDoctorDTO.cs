namespace HospitalManagementSystem.Application;

public record InputReferralDoctorDTO : ReferralDoctorDTO
{
    public string? ReferralDTOId            { get; init; }
    public string? AssignmentHistoryDTOId   { get; init; }
}