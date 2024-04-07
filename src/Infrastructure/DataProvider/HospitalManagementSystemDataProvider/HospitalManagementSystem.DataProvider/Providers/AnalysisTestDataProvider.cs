using CoreAnalysisTest = HospitalManagementSystem.Domain.AnalysisTest;
using DataAnalysisTest = HospitalManagementSystem.DataProvider.AnalysisTest;

namespace HospitalManagementSystem.DataProvider;

public class AnalysisTestDataProvider<TDbContext> : DataProviderBase<TDbContext, CoreAnalysisTest, DataAnalysisTest>, IAnalysisTestDataProvider
    where TDbContext : DbContext
{
    public AnalysisTestDataProvider(TDbContext context, IMapper mapper) : base(context, mapper)
    {
    }
}
