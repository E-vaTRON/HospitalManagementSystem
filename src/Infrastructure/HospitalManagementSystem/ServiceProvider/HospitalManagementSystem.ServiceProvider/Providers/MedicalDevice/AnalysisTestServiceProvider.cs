using CoreAnalysisTest = HospitalManagementSystem.Domain.AnalysisTest;
using DTOAnalysisTestIn = HospitalManagementSystem.Application.InputAnalysisTestDTO;
using DTOAnalysisTestOut = HospitalManagementSystem.Application.OutputAnalysisTestDTO;

namespace HospitalManagementSystem.ServiceProvider;

public class AnalysisTestServiceProvider : ServiceProviderBase<DTOAnalysisTestOut, DTOAnalysisTestIn, CoreAnalysisTest>, IAnalysisTestServiceProvider
{
    #region [ Fields ]
    protected IAnalysisTestDataProvider AnalysisTestDataProvider;
    #endregion

    #region [ Methods ]
    public AnalysisTestServiceProvider(IAnalysisTestDataProvider dataProvider, IMapper mapper) : base(dataProvider, mapper)
    {
        AnalysisTestDataProvider = dataProvider;
    }
    #endregion

    #region [ Methods ]
    public async Task<IList<DTOAnalysisTestOut>> GetAllIncludeServiceAsync()
    {
        var analysisTest = await AnalysisTestDataProvider.GetAllIncludeServiceAsync();
        return MapToDTOs(analysisTest).ToList();
    }

    public async Task<DTOAnalysisTestOut> GetByIdIncludeServiceAsync(string id, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(id, nameof(id));
        var analysisTest = await AnalysisTestDataProvider.GetByIdIncludeServiceAsync(id, cancellationToken);
        return MapToDTO(analysisTest)!;
    }

    public async Task<IList<DTOAnalysisTestOut>> GetMultipleByIdIncludeServiceAsync(string[] ids, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(ids, nameof(ids));
        var analysisTests = await AnalysisTestDataProvider.GetMultipleByIdIncludeServiceAsync(ids, cancellationToken);
        return MapToDTOs(analysisTests).ToList();
    }
    #endregion
}