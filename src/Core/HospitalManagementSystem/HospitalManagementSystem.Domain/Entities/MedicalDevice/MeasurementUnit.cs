namespace HospitalManagementSystem.Domain;

public class MeasurementUnit : EntityBase
{
    public string?  Name    { get; set; }
    public string?  Symbol  { get; set; }

    public virtual ICollection<DeviceUnit> DeviceUnits { get; set; } = new HashSet<DeviceUnit>();
}
