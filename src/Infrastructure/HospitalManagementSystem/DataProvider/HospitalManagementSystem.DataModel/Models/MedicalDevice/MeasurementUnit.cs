namespace HospitalManagementSystem.DataProvider;

public class MeasurementUnit : ModelBase
{
    public string? Name     { get; set; }
    public string? Symbol   { get; set; }

    public virtual ICollection<DeviceUnit> DeviceUnits { get; set; } = new HashSet<DeviceUnit>();
}
