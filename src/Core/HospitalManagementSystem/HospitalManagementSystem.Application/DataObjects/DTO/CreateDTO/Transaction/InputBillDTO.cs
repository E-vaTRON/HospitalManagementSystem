namespace HospitalManagementSystem.Application;

public record InputBillDTO : BillDTO
{
    public Guid? MedicalExamEpisodeId { get; init; }
}
