namespace HospitalManagementSystem.Application;

public record OutputStorageDTO : StorageDTO
{
    public ICollection<OutputDrugInventoryDTO>?   DrugInventories   { get; init; }
    public ICollection<OutputDeviceInventoryDTO>? DeviceInventories { get; init; }
}
