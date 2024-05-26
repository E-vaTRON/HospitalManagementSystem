using DTOAnalysisTestIn = HospitalManagementSystem.Application.InputAnalysisTestDTO;
using DTOAnalysisTestOut = HospitalManagementSystem.Application.OutputAnalysisTestDTO;

namespace HospitalManagementSystem.REST;

public class AnalysisTestController : BaseHMSController<DTOAnalysisTestOut, DTOAnalysisTestIn>
{
    public AnalysisTestController(IAnalysisTestServiceProvider serviceProvider) : base(serviceProvider)
    {
    }
}