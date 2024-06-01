namespace HospitalManagementSystem.Application;

public record OutputDeviceInventoryDTO : DeviceInventoryDTO
{
    public OutputMedicalDeviceDTO?    MedicalDeviceDTO    { get; init; }
    public OutputStorageDTO?          StorageDTO          { get; init; }

    public virtual ICollection<OutputDeviceServiceDTO>? DeviceServiceDTOs { get; init; }
}
