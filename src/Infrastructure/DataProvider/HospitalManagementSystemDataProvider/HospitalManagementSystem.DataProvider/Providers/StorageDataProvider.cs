using CoreStorage = HospitalManagementSystem.Domain.Storage;
using DataStorage = HospitalManagementSystem.DataProvider.Storage;

namespace HospitalManagementSystem.DataProvider;

public class StorageDataProvider<TDbContext> : DataProviderBase<TDbContext, CoreStorage, DataStorage>, IStorageDataProvider
    where TDbContext : DbContext
{
    public StorageDataProvider(TDbContext context, IMapper mapper) : base(context, mapper)
    {
    }
}
