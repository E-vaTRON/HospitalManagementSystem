﻿using CoreDrug = HospitalManagementSystem.Domain.Drug;
using DataDrug = HospitalManagementSystem.DataProvider.Drug;

namespace HospitalManagementSystem.DataProvider;

public class DrugDataProvider : DataProviderBase<CoreDrug, DataDrug>, IDrugDataProvider
{
    public DrugDataProvider(HospitalManagementSystemDbContext context, IMapper mapper) : base(context, mapper)
    {
    }
}
