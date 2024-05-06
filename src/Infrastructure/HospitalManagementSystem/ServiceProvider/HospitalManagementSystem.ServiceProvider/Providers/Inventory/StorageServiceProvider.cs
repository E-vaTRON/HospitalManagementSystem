using CoreStorage = HospitalManagementSystem.Domain.Storage;

namespace HospitalManagementSystem.ServiceProvider;

public class StorageServiceProvider : ServiceProviderBase<CoreStorage>, IStorageServiceProvider
{
    public StorageServiceProvider(StorageDataProvider dataProvider) : base(dataProvider)
    {
    }
}
