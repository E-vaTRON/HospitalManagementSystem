namespace HospitalManagementSystem.Application;

public interface IMedicalExamEpisodeServiceProvider : IServiceProviderBase<OutputMedicalExamEpisodeDTO, InputMedicalExamEpisodeDTO, string>
{
    Task<IList<OutputMedicalExamEpisodeDTO>> GetMedicalExamEpisodeByIdAsync(string id, CancellationToken cancellationToken = default!);
}
