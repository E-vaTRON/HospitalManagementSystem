using CoreAssignmentHistory = HospitalManagementSystem.Domain.AssignmentHistory;
using DTOAssignmentHistoryIn = HospitalManagementSystem.Application.InputAssignmentHistoryDTO;
using DTOAssignmentHistoryOut = HospitalManagementSystem.Application.OutputAssignmentHistoryDTO;

namespace HospitalManagementSystem.ServiceProvider;

public class AssignmentHistoryServiceProvider : ServiceProviderBase<DTOAssignmentHistoryOut, DTOAssignmentHistoryIn, CoreAssignmentHistory>, IAssignmentHistoryServiceProvider
{
    public AssignmentHistoryServiceProvider(IAssignmentHistoryDataProvider dataProvider, IMapper mapper) : base(dataProvider, mapper)
    {
    }
}
