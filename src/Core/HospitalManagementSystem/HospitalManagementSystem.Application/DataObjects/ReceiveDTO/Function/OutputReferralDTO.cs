namespace HospitalManagementSystem.Application;

public record OutputReferralDTO : ReferralDTO
{
    public MedicalExamDTO? MedicalExamDTO { get; set; }

    public ICollection<AssignmentHistoryDTO>? AssignmentHistoryDTOs { get; set; }
}
