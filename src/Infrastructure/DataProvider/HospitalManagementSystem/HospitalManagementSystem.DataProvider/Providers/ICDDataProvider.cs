﻿using CoreICD = HospitalManagementSystem.Domain.Diseases;
using DataICD = HospitalManagementSystem.DataProvider.Diseases;

namespace HospitalManagementSystem.DataProvider;

public class ICDDataProvider : DataProviderBase<CoreICD, DataICD>, IDiseasesDataProvider
{
    public ICDDataProvider(HospitalManagementSystemDbContext context, IMapper mapper) : base(context, mapper)
    {
    }
}