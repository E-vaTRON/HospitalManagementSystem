namespace HospitalManagementSystem.Application;

public record OutputServiceEpisodeDTO : ServiceEpisodeDTO
{
    public OutputMedicalExamEpisodeDTO?     MedicalExamEpisode  { get; init; }
    public OutputMedicalServiceDTO?         MedicalService      { get; init; }

    //public ICollection<OutputAnalysisTestDTO>? AnalysisTests { get; init; }
}