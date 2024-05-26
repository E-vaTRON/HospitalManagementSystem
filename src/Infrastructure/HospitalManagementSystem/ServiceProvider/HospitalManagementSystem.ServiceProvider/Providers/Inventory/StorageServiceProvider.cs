using CoreStorage = HospitalManagementSystem.Domain.Storage;
using DTOStorageIn = HospitalManagementSystem.Application.InputStorageDTO;
using DTOStorageOut = HospitalManagementSystem.Application.OutputStorageDTO;

namespace HospitalManagementSystem.ServiceProvider;

public class StorageServiceProvider : ServiceProviderBase<DTOStorageOut, DTOStorageIn, CoreStorage>, IStorageServiceProvider
{
    public StorageServiceProvider(IStorageDataProvider dataProvider, IMapper mapper) : base(dataProvider, mapper)
    {
    }
}
