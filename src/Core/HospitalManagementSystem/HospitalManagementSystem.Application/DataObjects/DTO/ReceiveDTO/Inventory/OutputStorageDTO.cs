namespace HospitalManagementSystem.Application;

public record OutputStorageDTO : StorageDTO
{
    public ICollection<OutputDrugInventoryDTO>?   DrugInventoryDTOs   { get; init; }
    public ICollection<OutputDeviceInventoryDTO>? DeviceInventoryDTOs { get; init; }
}
