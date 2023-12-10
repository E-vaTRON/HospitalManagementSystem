namespace HospitalManagementSystem.Domain;

public class DeviceService : EntityBase
{
    public string?          DeviceInventoryId   { get; set; }
    public DeviceInventory  DeviceInventory     { get; set; } = default!;
    public string?          ServiceId           { get; set; }
    public Service          Service             { get; set; } = default!;

    public virtual ICollection<AnalysisTest> AnalysisTests { get; set; } = new HashSet<AnalysisTest>();
}