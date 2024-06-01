namespace HospitalManagementSystem.Application;

public record InputBillDTO : BillDTO
{
    public string? MedicalExamEpisodeDTOId { get; init; }
}
