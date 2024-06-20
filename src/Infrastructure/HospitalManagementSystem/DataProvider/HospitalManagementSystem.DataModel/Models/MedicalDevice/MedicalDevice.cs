namespace HospitalManagementSystem.DataProvider;

public class MedicalDevice : ModelBase
{
    public string       Name            { get; set; } = string.Empty;      //tên thiết bị
    public string?      Country         { get; set; }                      //nước sản xuất 
    public string?      SmallID         { get; set; }                      //mã con /// ???
    public string?      GroupID         { get; set; }                      //mã số nhóm
    public int          Min             { get; set; }                      //MIN
    public int          Max             { get; set; }                      //MAX

    public virtual ICollection<DeviceInventory>     DeviceInventories    { get; set; } = new HashSet<DeviceInventory>();
}
