namespace HospitalManagementSystem.Application;

public record OutputGoodSupplingDTO : GoodSupplingDTO
{
    public DrugInventoryDTO?    InventoryDTO    { get; set; }
    public ImportationDTO?      ImportationDTO  { get; set; }
    public DrugDTO?             DrugDTO         { get; set; }
}
