﻿using CoreAssignmentHistory = HospitalManagementSystem.Domain.AssignmentHistory;
using DataAssignmentHistory = HospitalManagementSystem.DataProvider.AssignmentHistory;

namespace HospitalManagementSystem.DataProvider;

public class AssignmentHistoryDataProvider : DataProviderBase<CoreAssignmentHistory, DataAssignmentHistory>, IAssignmentHistoryServiceProvider
{
    public AssignmentHistoryDataProvider(HospitalManagementSystemDbContext context, IMapper mapper) : base(context, mapper)
    {
    }
}
