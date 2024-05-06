using CoreAssignmentHistory = HospitalManagementSystem.Domain.AssignmentHistory;

namespace HospitalManagementSystem.ServiceProvider;

public class AssignmentHistoryServiceProvider : ServiceProviderBase<CoreAssignmentHistory>, IAssignmentHistoryServiceProvider
{
    public AssignmentHistoryServiceProvider(AssignmentHistoryDataProvider dataProvider) : base(dataProvider)
    {
    }
}
