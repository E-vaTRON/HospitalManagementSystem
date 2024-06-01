namespace HospitalManagementSystem.Application;

public record OutputReferralDTO : ReferralDTO
{
    public OutputMedicalExamDTO? MedicalExamDTO { get; init; }

    public ICollection<OutputAssignmentHistoryDTO>? AssignmentHistoryDTOs { get; init; }
}
