using CoreAnalysisTest = HospitalManagementSystem.Domain.AnalysisTest;
using DTOAnalysisTestIn = HospitalManagementSystem.Application.InputAnalysisTestDTO;
using DTOAnalysisTestOut = HospitalManagementSystem.Application.OutputAnalysisTestDTO;

namespace HospitalManagementSystem.ServiceProvider;

public class AnalysisTestServiceProvider : ServiceProviderBase<DTOAnalysisTestOut, DTOAnalysisTestIn, CoreAnalysisTest>, IAnalysisTestServiceProvider
{
    public AnalysisTestServiceProvider(IAnalysisTestDataProvider dataProvider, IMapper mapper) : base(dataProvider, mapper)
    {
    }
}