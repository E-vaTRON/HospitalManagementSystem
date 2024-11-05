namespace HospitalManagementSystem.Domain;

public static class MeasurementUnitExtensions
{
    #region [ Private Methods ]
    private static MeasurementUnit AddDeviceUnit(this MeasurementUnit measurementUnit, DeviceUnit deviceUnit)
    {
        ArgumentException.ThrowIfNullOrEmpty(nameof(measurementUnit));
        ArgumentException.ThrowIfNullOrEmpty(nameof(deviceUnit));

        if (measurementUnit.DeviceUnits.Any(x => x.Id == measurementUnit.Id))
        {
            return measurementUnit;
        }

        deviceUnit.MeasurementUnitId = measurementUnit.Id;
        deviceUnit.MeasurementUnit = measurementUnit;
        measurementUnit.DeviceUnits.Add(deviceUnit);
        return measurementUnit;
    }
    #endregion

    #region [ Public Methods ]
    public static MeasurementUnit AddDeviceUnit(this MeasurementUnit medicalDevice)
    {
        return medicalDevice.AddDeviceUnit(DeviceUnitFactory.Create());
    }

    public static MeasurementUnit RemoveRelated(this MeasurementUnit measurementUnit)
    {
        measurementUnit.DeviceUnits.Clear();
        return measurementUnit;
    }
    #endregion
}
