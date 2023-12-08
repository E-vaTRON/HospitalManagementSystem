namespace HospitalManagementSystem.Domain;

public class DeviceService : EntityBase
{
    public string?          DeviceId { get; set; }
    public DeviceInventory  Device { get; set; } = default!;
    public string?          ServiceId { get; set; }
    public Service          Service { get; set; } = default!;

    public virtual ICollection<AnalysisTest> AnalysisTests { get; set; } = new HashSet<AnalysisTest>();
}
