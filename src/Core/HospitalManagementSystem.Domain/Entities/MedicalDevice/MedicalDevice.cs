namespace HospitalManagementSystem.Domain;

public class MedicalDevice : EntityBase
{
    public string       Name            { get; set; } = string.Empty;      //tên thiết bị
    public string?      ManagementID    { get; set; }                      //mã quản lí
    public string?      Country         { get; set; }                      //nước sản xuất 
    public string?      SmallID         { get; set; }                      //mã con
    public string?      GroupID         { get; set; }                      //mã số nhóm
    public int          Min             { get; set; }                      //MIN
    public int          Max             { get; set; }                      //MAX

    public virtual ICollection<DeviceInventory>     DeviceInventorys    { get; set; } = new HashSet<DeviceInventory>();
}
