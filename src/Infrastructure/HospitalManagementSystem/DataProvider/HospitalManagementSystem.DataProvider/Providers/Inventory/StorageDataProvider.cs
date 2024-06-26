﻿using CoreStorage = HospitalManagementSystem.Domain.Storage;
using DataStorage = HospitalManagementSystem.DataProvider.Storage;

namespace HospitalManagementSystem.DataProvider;

public class StorageDataProvider : DataProviderBase<CoreStorage, DataStorage>, IStorageDataProvider
{
    public StorageDataProvider(HospitalManagementSystemDbContext context, IMapper mapper) : base(context, mapper)
    {
    }
}
