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
    public async Task<IList<DTOMedicalExamEpisodeOut>> GetMedicalExamEpisodeByIdAsync(string id, CancellationToken cancellationToken = default)
    {
        var medicalExamEpisodes = await MedicalExamEpisodeDataProvider.GetMedicalExamEpisodeByIdAsync(id);
        ArgumentNullException.ThrowIfNull(medicalExamEpisodes, nameof(CoreMedicalExamEpisode));
        return MapToDTOs(medicalExamEpisodes).ToList();
    }
    #endregion
}