namespace HospitalManagementSystem.Application;

public record OutputMedicalDeviceDTO : MedicalDeviceDTO
{
    public ICollection<DeviceInventoryDTO>? DeviceInventoryDTOs { get; set; }
}