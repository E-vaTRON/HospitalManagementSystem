namespace HospitalManagementSystem.Application;

public record OutputBillDTO : BillDTO
{
    public OutputMedicalExamEpisodeDTO? MedicalExamEpisode { get; init; }
}
