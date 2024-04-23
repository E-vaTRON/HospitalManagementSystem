namespace HospitalManagementSystem.DataProvider;

public class DeviceInventory : ModelBase
{
    public int CurrentAmount { get; set; }       //số lượng hiện tại

    public Guid?            MedicalDeviceId     { get; set; }       //mã hàng
    public MedicalDevice    MedicalDevice       { get; set; } = default!;
    public Guid?            StorageId           { get; set; }       //mã kho
    public Storage          Storage             { get; set; } = default!;

    public virtual ICollection<DeviceService> DeviceServices { get; set; } = new HashSet<DeviceService>();
}
