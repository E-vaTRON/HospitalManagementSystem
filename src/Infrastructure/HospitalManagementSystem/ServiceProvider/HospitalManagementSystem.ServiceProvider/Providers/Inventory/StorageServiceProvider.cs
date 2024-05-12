using CoreStorage = HospitalManagementSystem.Domain.Storage;
using DTOStorage = HospitalManagementSystem.Application.StorageDTO;

namespace HospitalManagementSystem.ServiceProvider;

public class StorageServiceProvider : ServiceProviderBase<DTOStorage, CoreStorage>, IStorageServiceProvider
{
    public StorageServiceProvider(IStorageDataProvider dataProvider, IMapper mapper) : base(dataProvider, mapper)
    {
    }
}
