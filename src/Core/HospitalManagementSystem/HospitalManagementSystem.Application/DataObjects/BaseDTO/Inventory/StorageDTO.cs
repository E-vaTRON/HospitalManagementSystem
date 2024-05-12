namespace HospitalManagementSystem.Application;

public class StorageDTO : DTOBase
{
    public string Location { get; set; } = string.Empty;

    public virtual ICollection<DrugInventoryDTO>   GoodSupplingDTOs     { get; set; } = new HashSet<DrugInventoryDTO>();
    public virtual ICollection<DeviceInventoryDTO> DeviceInventoryDTOs  { get; set; } = new HashSet<DeviceInventoryDTO>();
}
