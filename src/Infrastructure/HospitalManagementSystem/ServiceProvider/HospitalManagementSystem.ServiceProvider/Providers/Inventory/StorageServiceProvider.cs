using CoreStorage = HospitalManagementSystem.Domain.Storage;

namespace HospitalManagementSystem.ServiceProvider;

public class StorageServiceProvider : ServiceProviderBase<CoreStorage>, IStorageServiceProvider
{
    public StorageServiceProvider(IStorageDataProvider dataProvider) : base(dataProvider)
    {
    }
}
