using CoreServiceEpisode = HospitalManagementSystem.Domain.ServiceEpisode;
using DataServiceEpisode = HospitalManagementSystem.DataProvider.ServiceEpisode;

namespace HospitalManagementSystem.DataProvider;

public class ServiceEpisodeDataProvider : DataProviderBase<CoreServiceEpisode, DataServiceEpisode>, IServiceEpisodeDataProvider
{
    #region [ CTor ]
    public ServiceEpisodeDataProvider(HospitalManagementSystemDbContext context, IMapper mapper) : base(context, mapper)
    {
    }
    #endregion

    #region [ Internal - Method ]    
    #endregion

    #region [ Public - Method ]
    #endregion
}
