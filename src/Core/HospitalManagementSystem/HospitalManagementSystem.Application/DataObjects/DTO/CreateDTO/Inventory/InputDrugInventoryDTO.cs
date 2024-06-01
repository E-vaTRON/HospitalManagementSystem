namespace HospitalManagementSystem.Application;

public record InputDrugInventoryDTO : DrugInventoryDTO
{
    public string? StorageDTOId         { get; init; }
    public string? ImportationDTOId     { get; init; }
    public string? DrugDTOId            { get; init; }
}
