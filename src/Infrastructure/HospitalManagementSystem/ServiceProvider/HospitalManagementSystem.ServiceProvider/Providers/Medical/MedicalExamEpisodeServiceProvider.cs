using CoreMedicalExamEpisode = HospitalManagementSystem.Domain.MedicalExamEpisode;
using DTOMedicalExamEpisodeIn = HospitalManagementSystem.Application.InputMedicalExamEpisodeDTO;
using DTOMedicalExamEpisodeOut = HospitalManagementSystem.Application.OutputMedicalExamEpisodeDTO;

namespace HospitalManagementSystem.ServiceProvider;

public class MedicalExamEpisodeServiceProvider : ServiceProviderBase<DTOMedicalExamEpisodeOut, DTOMedicalExamEpisodeIn, CoreMedicalExamEpisode>, IMedicalExamEpisodeServiceProvider
{
    #region [ Fields ]
    protected IMedicalExamEpisodeDataProvider MedicalExamEpisodeDataProvider;
    #endregion

    #region [ CTor ]
    public MedicalExamEpisodeServiceProvider(IMedicalExamEpisodeDataProvider dataProvider, IMapper mapper) : base(dataProvider, mapper)
    {
        MedicalExamEpisodeDataProvider = dataProvider;
    }
    #endregion

    #region [ Public - Methods ]
    public async Task<IEnumerable<DTOMedicalExamEpisodeOut>> FindByIdIncludedAsync(string[] ids, CancellationToken cancellationToken = default)
    {
        var medicalExamEpisodes = await MedicalExamEpisodeDataProvider.FindByIdIncludedAsync(ids, cancellationToken);
        ArgumentNullException.ThrowIfNull(medicalExamEpisodes, nameof(CoreMedicalExamEpisode));
        return MapToDTOs(medicalExamEpisodes);
    }

    public async Task<IEnumerable<DTOMedicalExamEpisodeOut>> FindByMedicalExamIdAsync(string[] ids, CancellationToken cancellationToken = default)
    {
        var medicalExamEpisodes = await MedicalExamEpisodeDataProvider.FindByMedicalExamIdAsync(ids, cancellationToken);
        return MapToDTOs(medicalExamEpisodes);
    }
    #endregion
}