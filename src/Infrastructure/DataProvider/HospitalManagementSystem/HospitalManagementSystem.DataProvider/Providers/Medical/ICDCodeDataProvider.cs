using CoreICDCode = HospitalManagementSystem.Domain.ICDCode;
using DataICDCode = HospitalManagementSystem.DataProvider.ICDCode;

namespace HospitalManagementSystem.DataProvider;

public class ICDCodeDataProvider : DataProviderBase<CoreICDCode, DataICDCode>, IICDCodeDataProvider
{
    public ICDCodeDataProvider(HospitalManagementSystemDbContext context, IMapper mapper) : base(context, mapper)
    { 
    }
}
