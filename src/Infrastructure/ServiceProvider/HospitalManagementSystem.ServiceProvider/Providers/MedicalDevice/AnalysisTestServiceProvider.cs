using CoreAnalysisTest = HospitalManagementSystem.Domain.AnalysisTest;

namespace HospitalManagementSystem.ServiceProvider;

public class AnalysisTestServiceProvider : ServiceProviderBase<CoreAnalysisTest>, IAnalysisTestServiceProvider
{
    public AnalysisTestServiceProvider(AnalysisTestDataProvider dataProvider) : base(dataProvider)
    {
    }
}
