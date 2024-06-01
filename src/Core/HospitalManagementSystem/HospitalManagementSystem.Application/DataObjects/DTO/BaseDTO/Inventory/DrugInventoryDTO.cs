namespace HospitalManagementSystem.Application;

public record DrugInventoryDTO : DTOBase
{
    public string   GoodInformation { get; init; } = string.Empty;
    public DateTime ExpiryDate      { get; init; }       //hạng dùng
    public int      OrinaryAmount   { get; init; }
    public int      CurrentAmount   { get; init; }       //số lượng hiện tại
}
