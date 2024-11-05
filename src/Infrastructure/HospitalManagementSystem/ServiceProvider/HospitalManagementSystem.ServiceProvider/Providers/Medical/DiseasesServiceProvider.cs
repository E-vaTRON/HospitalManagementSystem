using CoreDiseases = HospitalManagementSystem.Domain.Diseases;
using DTODiseasesIn = HospitalManagementSystem.Application.InputDiseasesDTO;
using DTODiseasesOut = HospitalManagementSystem.Application.OutputDiseasesDTO;

namespace HospitalManagementSystem.ServiceProvider;

public class DiseasesServiceProvider : ServiceProviderBase<DTODiseasesOut, DTODiseasesIn, CoreDiseases>, IDiseasesServiceProvider
{
    #region [ Fields ]
    protected readonly IDiseasesDataProvider DiseasesDataProvider;
    #endregion

    #region [ CTor ]
    public DiseasesServiceProvider(IDiseasesDataProvider dataProvider, IMapper mapper) : base(dataProvider, mapper)
    {
        DiseasesDataProvider = dataProvider;
    }
    #endregion

    #region [ Public Methods ]
    public async Task<IEnumerable<DTODiseasesOut>> FindAllWithIncludeAsync(CancellationToken cancellationToken = default!)
    {
        var diseasess = await DiseasesDataProvider.FindAllWithIncludeAsync(cancellationToken);
        var diseasesdtos = MapToDTOs(diseasess);
        return diseasesdtos;
    }
    #endregion
}