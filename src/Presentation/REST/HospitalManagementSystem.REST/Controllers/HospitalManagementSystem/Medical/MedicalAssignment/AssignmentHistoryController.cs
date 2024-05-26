using DTOAssignmentHistoryIn = HospitalManagementSystem.Application.InputAssignmentHistoryDTO;
using DTOAssignmentHistoryOut = HospitalManagementSystem.Application.OutputAssignmentHistoryDTO;

namespace HospitalManagementSystem.REST;

public class AssignmentHistoryController : BaseHMSController<DTOAssignmentHistoryOut, DTOAssignmentHistoryIn>
{
    public AssignmentHistoryController(IAssignmentHistoryServiceProvider serviceProvider) : base(serviceProvider)
    {
    }
}
