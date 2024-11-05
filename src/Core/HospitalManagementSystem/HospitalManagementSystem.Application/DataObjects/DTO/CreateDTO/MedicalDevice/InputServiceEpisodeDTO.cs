namespace HospitalManagementSystem.Application;

public record InputServiceEpisodeDTO : ServiceEpisodeDTO
{
    public string? MedicalExamEpisodeDTOId  { get; init; }
    public string? ServiceDTOId             { get; init; }
}