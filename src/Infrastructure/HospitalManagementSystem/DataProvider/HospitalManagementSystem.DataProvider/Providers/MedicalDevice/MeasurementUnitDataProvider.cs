using CoreMeasurementUnit = HospitalManagementSystem.Domain.MeasurementUnit;
using DataMeasurementUnit = HospitalManagementSystem.DataProvider.MeasurementUnit;

namespace HospitalManagementSystem.DataProvider;

class MeasurementUnitDataProvider : DataProviderBase<CoreMeasurementUnit, DataMeasurementUnit>, IMeasurementUnitDataProvider
{
    #region [ CTor ]
    public MeasurementUnitDataProvider(HospitalManagementSystemDbContext context, IMapper mapper) : base(context, mapper)
    {
    }
    #endregion
}
