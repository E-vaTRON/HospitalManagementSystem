using CoreAssignmentHistory = HospitalManagementSystem.Domain.AssignmentHistory;
using DTOAssignmentHistory = HospitalManagementSystem.Application.AssignmentHistoryDTO;

namespace HospitalManagementSystem.ServiceProvider;

public class AssignmentHistoryServiceProvider : ServiceProviderBase<DTOAssignmentHistory, CoreAssignmentHistory>, IAssignmentHistoryServiceProvider
{
    public AssignmentHistoryServiceProvider(IAssignmentHistoryDataProvider dataProvider, IMapper mapper) : base(dataProvider, mapper)
    {
    }
}
