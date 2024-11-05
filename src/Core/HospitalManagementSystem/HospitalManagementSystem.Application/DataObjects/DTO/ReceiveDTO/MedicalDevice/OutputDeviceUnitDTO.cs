namespace HospitalManagementSystem.Application;

public record OutputDeviceUnitDTO : DeviceUnitDTO
{
    public OutputMedicalDeviceDTO?       MedicalDevice   { get; init; }
    public OutputMeasurementUnitDTO?     MeasurementUnit { get; init; }
}
