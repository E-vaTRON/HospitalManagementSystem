using CoreServiceEpisode = HospitalManagementSystem.Domain.ServiceEpisode;
using DTOServiceEpisodeIn = HospitalManagementSystem.Application.InputServiceEpisodeDTO;
using DTOServiceEpisodeOut = HospitalManagementSystem.Application.OutputServiceEpisodeDTO;

namespace HospitalManagementSystem.ServiceProvider;

public class ServiceEpisodeServiceProvider : ServiceProviderBase<DTOServiceEpisodeOut, DTOServiceEpisodeIn, CoreServiceEpisode>, IServiceEpisodeServiceProvider
{
    #region [ Fields ]
    protected readonly IServiceEpisodeDataProvider ServiceEpisodeDataProvider;
    #endregion

    #region [ CTor ]
    public ServiceEpisodeServiceProvider(IServiceEpisodeDataProvider dataProvider, IMapper mapper) : base(dataProvider, mapper)
    {
        ServiceEpisodeDataProvider = dataProvider;
    }
    #endregion

    #region [ Method ]
    #endregion
}