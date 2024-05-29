namespace HospitalManagementSystem.Application;

public record OutputBillDTO : BillDTO
{
    public MedicalExamEpisode? MedicalExamEpisode { get; init; }
}
