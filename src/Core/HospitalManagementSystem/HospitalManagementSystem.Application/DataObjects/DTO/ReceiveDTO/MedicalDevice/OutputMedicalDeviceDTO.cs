namespace HospitalManagementSystem.Application;

public record OutputMedicalDeviceDTO : MedicalDeviceDTO
{
    public ICollection<OutputDeviceInventoryDTO>? DeviceInventoryDTOs { get; init; }
}