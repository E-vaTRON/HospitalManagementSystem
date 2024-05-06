namespace HospitalManagementSystem.DataProvider;

public class DeviceService : ModelBase
{
    public Guid?            DeviceInventoryId   { get; set; }
    public DeviceInventory  DeviceInventory     { get; set; } = default!;
    public Guid?            ServiceId           { get; set; }
    public Service          Service             { get; set; } = default!;

    public virtual ICollection<AnalysisTest> AnalysisTests { get; set; } = new HashSet<AnalysisTest>();
}