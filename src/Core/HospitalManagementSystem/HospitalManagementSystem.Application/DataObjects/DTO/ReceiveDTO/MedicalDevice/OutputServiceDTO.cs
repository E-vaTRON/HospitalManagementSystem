namespace HospitalManagementSystem.Application;

public record OutputServiceDTO : ServiceDTO
{
    public ICollection<OutputDeviceServiceDTO>? DeviceServiceDTOs { get; init; }
}