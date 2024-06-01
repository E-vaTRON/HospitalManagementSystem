namespace HospitalManagementSystem.Application;

public record OutputBillDTO : BillDTO
{
    public OutputMedicalExamEpisodeDTO? MedicalExamEpisodeDTO { get; init; }
}
