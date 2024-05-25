namespace HospitalManagementSystem.Application;

public record OutputServiceDTO : ServiceDTO
{
    public ICollection<DeviceServiceDTO>? DeviceServiceDTOs { get; set; }
}