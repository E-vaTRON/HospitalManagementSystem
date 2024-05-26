namespace HospitalManagementSystem.Application;

public record OutputDeviceServiceDTO : DeviceServiceDTO
{
    public DeviceInventoryDTO?  DeviceInventoryDTO  { get; init; }
    public ServiceDTO?          ServiceDTO          { get; init; }

    public ICollection<AnalysisTestDTO>? AnalysisTestDTOs { get; init; }
}