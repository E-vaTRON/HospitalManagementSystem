using CoreAnalysisTest = HospitalManagementSystem.Domain.AnalysisTest;
using DataAnalysisTest = HospitalManagementSystem.DataProvider.AnalysisTest;

namespace HospitalManagementSystem.DataProvider
{
    public class AnalysisTestDataProvider : DataProviderBase<CoreAnalysisTest, DataAnalysisTest>, IAnalysisTestDataProvider
    {
        public AnalysisTestDataProvider(HospitalManagementSystemDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
