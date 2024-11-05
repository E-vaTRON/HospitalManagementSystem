namespace HospitalManagementSystem.Domain;

public class DeviceUnit : EntityBase
{
    public string?          MedicalDeviceId     { get; set; }
    public MedicalDevice    MedicalDevice       { get; set; } = default!;
    public string?          MeasurementUnitId   { get; set; }
    public MeasurementUnit  MeasurementUnit     { get; set; } = default!;
}
