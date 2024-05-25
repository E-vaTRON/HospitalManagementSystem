namespace HospitalManagementSystem.Application;

public record InputDeviceServiceDTO : DeviceServiceDTO
{
    public string? DeviceInventoryDTOId     { get; init; }
    public string? ServiceDTOId             { get; init; }
}