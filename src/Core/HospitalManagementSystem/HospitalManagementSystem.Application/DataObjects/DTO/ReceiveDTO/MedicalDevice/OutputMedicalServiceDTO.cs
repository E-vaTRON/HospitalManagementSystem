namespace HospitalManagementSystem.Application;

public record OutputMedicalServiceDTO : MedicalServiceDTO
{
    public ICollection<OutputServiceEpisodeDTO>? ServiceEpisodes { get; init; }
}