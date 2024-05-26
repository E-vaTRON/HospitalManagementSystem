namespace HospitalManagementSystem.Application;

public record InputDrugInventoryDTO : DrugInventoryDTO
{
    public string? StorageDTOId         { get; init; }
    public string? GoodSupplingDTOId    { get; init; }
}
