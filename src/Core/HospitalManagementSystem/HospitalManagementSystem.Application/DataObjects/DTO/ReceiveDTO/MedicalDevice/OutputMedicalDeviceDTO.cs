namespace HospitalManagementSystem.Application;

public record OutputMedicalDeviceDTO : MedicalDeviceDTO
{
    public ICollection<OutputDeviceInventoryDTO>?   DeviceInventories   { get; init; }
    public ICollection<OutputDeviceUnitDTO>?        DeviceUnits         { get; init; }
    public ICollection<OutputMedicalDeviceFormDTO>? MedicalDeviceForms  { get; init; }
}