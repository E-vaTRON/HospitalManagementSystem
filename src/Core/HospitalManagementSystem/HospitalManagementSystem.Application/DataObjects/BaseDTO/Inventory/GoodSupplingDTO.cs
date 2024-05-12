namespace HospitalManagementSystem.Application;

public class GoodSupplingDTO : DTOBase
{
    public string   GoodInformation { get; set; } = string.Empty;
    public DateTime ExpiryDate      { get; set; }       //hạng dùng
    public int      OrinaryAmount   { get; set; }


    public DrugInventoryDTO?    InventoryDTO    { get; set; }
    public ImportationDTO?      ImportationDTO  { get; set; }
    public DrugDTO?             DrugDTO         { get; set; }

}
