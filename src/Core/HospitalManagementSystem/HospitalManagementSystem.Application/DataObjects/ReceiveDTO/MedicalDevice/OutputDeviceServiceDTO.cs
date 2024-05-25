namespace HospitalManagementSystem.Application;

public record OutputDeviceServiceDTO : DeviceServiceDTO
{
    public DeviceInventoryDTO?  DeviceInventoryDTO  { get; set; }
    public ServiceDTO?          ServiceDTO          { get; set; }

    public ICollection<AnalysisTestDTO>? AnalysisTestDTOs { get; set; }
}