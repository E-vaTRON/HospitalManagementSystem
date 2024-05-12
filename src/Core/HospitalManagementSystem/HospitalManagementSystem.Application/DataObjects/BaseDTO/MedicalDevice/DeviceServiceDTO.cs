namespace HospitalManagementSystem.Application;

public class DeviceServiceDTO : DTOBase
{
    public DeviceInventoryDTO  DeviceInventoryDTO     { get; set; } = default!;
    public ServiceDTO          ServiceDTO             { get; set; } = default!;

    public virtual ICollection<AnalysisTestDTO> AnalysisTestDTOs { get; set; } = new HashSet<AnalysisTestDTO>();
}