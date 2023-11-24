namespace HospitalManagementSystem.Application;

public class InventoryDTO
{
    public int      InventoryID     { get; set; }
    public string   GoodID          { get; set; } = string.Empty;       //mã hàng
    public string   ShipmentID      { get; set; } = string.Empty;       //số lô
    public string   ExpiryDate      { get; set; } = string.Empty;       //hạng dùng
    public int      CurrentAmount   { get; set; }                       //số lượng hiện tại
}
