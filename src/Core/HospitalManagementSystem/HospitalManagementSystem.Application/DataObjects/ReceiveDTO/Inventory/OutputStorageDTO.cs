namespace HospitalManagementSystem.Application;

public record OutputStorageDTO : StorageDTO
{
    public ICollection<DrugInventoryDTO>?   DrugInventoryDTOs   { get; set; }
    public ICollection<DeviceInventoryDTO>? DeviceInventoryDTOs { get; set; }
}
