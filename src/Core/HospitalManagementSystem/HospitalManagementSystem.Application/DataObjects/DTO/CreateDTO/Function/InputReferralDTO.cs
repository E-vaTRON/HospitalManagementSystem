namespace HospitalManagementSystem.Application;

public record InputReferralDTO : ReferralDTO
{
    public string? MedicalExamDTOId { get; init; }
}

