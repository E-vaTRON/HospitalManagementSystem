namespace HospitalManagementSystem.Application;

public record OutputGoodSupplingDTO : GoodSupplingDTO
{
    public DrugInventoryDTO?    InventoryDTO    { get; init; }
    public ImportationDTO?      ImportationDTO  { get; init; }
    public DrugDTO?             DrugDTO         { get; init; }
}
