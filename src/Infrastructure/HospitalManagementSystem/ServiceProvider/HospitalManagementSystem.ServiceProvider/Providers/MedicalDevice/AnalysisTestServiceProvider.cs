using CoreAnalysisTest = HospitalManagementSystem.Domain.AnalysisTest;
using DTOAnalysisTest = HospitalManagementSystem.Application.AnalysisTestDTO;

namespace HospitalManagementSystem.ServiceProvider;

public class AnalysisTestServiceProvider : ServiceProviderBase<DTOAnalysisTest, CoreAnalysisTest>, IAnalysisTestServiceProvider
{
    public AnalysisTestServiceProvider(IAnalysisTestDataProvider dataProvider, IMapper mapper) : base(dataProvider, mapper)
    {
    }
}
