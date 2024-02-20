namespace HospitalManagementSystem.DataBaseContextProvider;

public class DeviceInventory : ModelBase
{
    public int CurrentAmount { get; set; }       //số lượng hiện tại

    public string?          MedicalDeviceID     { get; set; }       //mã hàng
    public MedicalDevice    MedicalDevice       { get; set; } = default!;
    public string?          StorageID           { get; set; }       //mã kho
    public Storage          Storage             { get; set; } = default!;

    public virtual ICollection<DeviceService> DeviceServices { get; set; } = new HashSet<DeviceService>();
}
