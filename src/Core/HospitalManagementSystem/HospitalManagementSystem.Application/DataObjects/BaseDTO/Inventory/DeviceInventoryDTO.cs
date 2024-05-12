namespace HospitalManagementSystem.Application;

public class DeviceInventoryDTO : DTOBase
{
    public int CurrentAmount { get; set; }       //số lượng hiện tại

    public MedicalDeviceDTO MedicalDeviceDTO       { get; set; } = default!;
    public StorageDTO       StorageDTO             { get; set; } = default!;

    public virtual ICollection<DeviceServiceDTO> DeviceServiceDTOs { get; set; } = new HashSet<DeviceServiceDTO>();
}
