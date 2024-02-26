namespace HospitalManagementSystem.Domain;

public class DeviceInventory : EntityBase
{
    public int CurrentAmount { get; set; }       //số lượng hiện tại

    public string?          MedicalDeviceId     { get; set; }       //mã hàng
    public MedicalDevice    MedicalDevice       { get; set; } = default!;
    public string?          StorageId           { get; set; }       //mã kho
    public Storage          Storage             { get; set; } = default!;

    public virtual ICollection<DeviceService> DeviceServices { get; set; } = new HashSet<DeviceService>();
}
