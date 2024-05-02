using CoreICD = HospitalManagementSystem.Domain.Diseases;
using DataICD = HospitalManagementSystem.DataProvider.Diseases;

namespace HospitalManagementSystem.DataProvider;

public class DiseasesDataProvider : DataProviderBase<CoreICD, DataICD>, IDiseasesDataProvider
{
    public DiseasesDataProvider(HospitalManagementSystemDbContext context, IMapper mapper) : base(context, mapper)
    {
    }
}
