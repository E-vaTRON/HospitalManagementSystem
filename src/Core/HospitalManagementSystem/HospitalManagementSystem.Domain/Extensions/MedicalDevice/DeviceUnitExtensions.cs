namespace HospitalManagementSystem.Domain;

public static class DeviceUnitExtensions
{
    #region [ Public Methods ]
    public static DeviceUnit RemoveRelated(this DeviceUnit deviceUnit)
    {
        deviceUnit.MeasurementUnit = null!;
        deviceUnit.MedicalDevice = null!;
        return deviceUnit;
    }
    #endregion
}
