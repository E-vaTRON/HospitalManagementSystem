namespace HospitalManagementSystem.Application;

public interface IMedicalExamEpisodeDataProvider : IDataProviderBase<MedicalExamEpisode, string>
{
    Task<IList<MedicalExamEpisode>> GetMedicalExamEpisodeByIdAsync(string id, CancellationToken cancellationToken = default!);
}
