namespace HospitalManagementSystem.Application;

public record OutputReferralDTO : ReferralDTO
{
    public MedicalExamDTO? MedicalExamDTO { get; init; }

    public ICollection<AssignmentHistoryDTO>? AssignmentHistoryDTOs { get; init; }
}
