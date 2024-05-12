using CoreICDVersion = HospitalManagementSystem.Domain.ICDVersion;
using DataICDVersion = HospitalManagementSystem.DataProvider.ICDVersion;

namespace HospitalManagementSystem.DataProvider;

public class ICDVersionDataProvider : DataProviderBase<CoreICDVersion, DataICDVersion>, IICDVersionDataProvider
{
    public ICDVersionDataProvider(HospitalManagementSystemDbContext context, IMapper mapper) : base(context, mapper)
    {
    }
}
