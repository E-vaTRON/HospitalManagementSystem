namespace HospitalManagementSystem.DataProvider;

public class DeviceUnit : ModelBase
{
    public Guid?            MedicalDeviceId     { get; set; }
    public MedicalDevice    MedicalDevice       { get; set; } = default!;
    public Guid?            MeasurementUnitId   { get; set; }
    public MeasurementUnit  MeasurementUnit     { get; set; } = default!;
}
