namespace HospitalManagementSystem.Application;

public record InputDeviceInventoryDTO : DeviceInventoryDTO
{
    public string? MedicalDeviceDTOId   { get; init; }
    public string? StorageDTOId         { get; init; }
}