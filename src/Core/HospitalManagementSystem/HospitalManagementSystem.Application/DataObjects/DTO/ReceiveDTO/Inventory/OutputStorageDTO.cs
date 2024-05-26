namespace HospitalManagementSystem.Application;

public record OutputStorageDTO : StorageDTO
{
    public ICollection<DrugInventoryDTO>?   DrugInventoryDTOs   { get; init; }
    public ICollection<DeviceInventoryDTO>? DeviceInventoryDTOs { get; init; }
}
