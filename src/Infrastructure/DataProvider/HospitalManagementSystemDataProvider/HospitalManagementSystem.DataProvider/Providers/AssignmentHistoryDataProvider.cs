using CoreAssignmentHistory = HospitalManagementSystem.Domain.AssignmentHistory;
using DataAssignmentHistory = HospitalManagementSystem.DataProvider.AssignmentHistory;

namespace HospitalManagementSystem.DataProvider;

public class AssignmentHistoryDataProvider<TDbContext> : DataProviderBase<TDbContext, CoreAssignmentHistory, DataAssignmentHistory>, IAssignmentHistoryDataProvider
    where TDbContext : DbContext
{
    public AssignmentHistoryDataProvider(TDbContext context, IMapper mapper) : base(context, mapper)
    {
    }
}
