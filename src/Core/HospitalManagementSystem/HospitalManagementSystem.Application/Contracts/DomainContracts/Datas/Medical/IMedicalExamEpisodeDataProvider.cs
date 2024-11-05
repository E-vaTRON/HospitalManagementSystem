namespace HospitalManagementSystem.Application;

public interface IMedicalExamEpisodeDataProvider : IDataProviderBase<MedicalExamEpisode, string>
{
    Task<IList<MedicalExamEpisode>> FindByIdIncludedAsync(string[] ids, CancellationToken cancellationToken = default);

    Task<IEnumerable<MedicalExamEpisode>> FindByMedicalExamIdAsync(string[] ids, CancellationToken cancellationToken = default!);
}
