namespace HospitalManagementSystem.Application;

public record InputDeviceUnitDTO : DeviceUnitDTO
{
    public string? MedicalDeviceId      { get; set; }
    public string? MeasurementUnitId    { get; set; }
}
