namespace HospitalManagementSystem.Application;

public record InputGoodSupplingDTO : GoodSupplingDTO
{
    public string? InventoryDTOId   { get; init; }
    public string? ImportationDTOId { get; init; }
    public string? DrugDTOId        { get; init; }
}
