namespace HospitalManagementSystem.Application;

public record OutputReferralDTO : ReferralDTO
{
    public OutputMedicalExamDTO? MedicalExam { get; init; }

    public ICollection<OutputAssignmentHistoryDTO>? AssignmentHistories { get; init; }
}
