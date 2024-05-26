namespace HospitalManagementSystem.Application;

public record OutputDeviceInventoryDTO : DeviceInventoryDTO
{
    public MedicalDeviceDTO?    MedicalDeviceDTO    { get; init; }
    public StorageDTO?          StorageDTO          { get; init; }

    public virtual ICollection<DeviceServiceDTO>? DeviceServiceDTOs { get; init; }
}
