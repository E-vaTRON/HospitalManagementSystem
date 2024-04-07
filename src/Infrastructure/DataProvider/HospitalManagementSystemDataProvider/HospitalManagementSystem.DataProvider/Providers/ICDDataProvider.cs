﻿using CoreICD = HospitalManagementSystem.Domain.ICD;
using DataICD = HospitalManagementSystem.DataProvider.ICD;

namespace HospitalManagementSystem.DataProvider;

public class ICDDataProvider : DataProviderBase<CoreICD, DataICD>, IICDDataProvider
{
    public ICDDataProvider(HospitalManagementSystemDbContext context, IMapper mapper) : base(context, mapper)
    {
    }
}