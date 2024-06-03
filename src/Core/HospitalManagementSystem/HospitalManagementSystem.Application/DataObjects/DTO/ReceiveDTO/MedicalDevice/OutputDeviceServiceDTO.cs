namespace HospitalManagementSystem.Application;

public record OutputDeviceServiceDTO : DeviceServiceDTO
{
    public OutputDeviceInventoryDTO?  DeviceInventoryDTO  { get; init; }
    public OutputServiceDTO?          ServiceDTO          { get; init; }

    public ICollection<OutputAnalysisTestDTO>? AnalysisTestDTOs { get; init; }
}