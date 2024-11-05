namespace HospitalManagementSystem.Application;

public interface IMedicalExamEpisodeServiceProvider : IServiceProviderBase<OutputMedicalExamEpisodeDTO, InputMedicalExamEpisodeDTO, string>
{
    Task<IEnumerable<OutputMedicalExamEpisodeDTO>> FindByIdIncludedAsync(string[] ids, CancellationToken cancellationToken = default);

    Task<IEnumerable<OutputMedicalExamEpisodeDTO>> FindByMedicalExamIdAsync(string[] ids, CancellationToken cancellationToken = default!);
}
