using CoreICDCodeVersion = HospitalManagementSystem.Domain.ICDCodeVersion;
using DataICDCodeVersion = HospitalManagementSystem.DataProvider.ICDCodeVersion;

namespace HospitalManagementSystem.DataProvider
{
    public class ICDCodeVersionDataProvider : DataProviderBase<CoreICDCodeVersion, DataICDCodeVersion>, IICDCodeVersionDataProvider
    {
        public ICDCodeVersionDataProvider(HospitalManagementSystemDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
