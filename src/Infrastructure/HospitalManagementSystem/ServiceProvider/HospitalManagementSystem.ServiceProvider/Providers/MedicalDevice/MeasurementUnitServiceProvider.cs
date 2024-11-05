using CoreMeasurementUnit = HospitalManagementSystem.Domain.MeasurementUnit;
using DTOMeasurementUnitIn = HospitalManagementSystem.Application.InputMeasurementUnitDTO;
using DTOMeasurementUnitOut = HospitalManagementSystem.Application.OutputMeasurementUnitDTO;

namespace HospitalManagementSystem.ServiceProvider;

public class MeasurementUnitServiceProvider : ServiceProviderBase<DTOMeasurementUnitOut, DTOMeasurementUnitIn, CoreMeasurementUnit>, IMeasurementUnitServiceProvider
{
    #region [ CTor ]
    public MeasurementUnitServiceProvider(IMeasurementUnitDataProvider dataProvider, IMapper mapper) : base(dataProvider, mapper)
    {
    }
    #endregion
}
