namespace HospitalManagementSystem.Domain;

public class Storage : EntityBase
{
    public string Location { get; set; } = string.Empty;

    public virtual ICollection<DrugInventory>   DrugInventories     { get; set; } = new HashSet<DrugInventory>();
    public virtual ICollection<DeviceInventory> DeviceInventories   { get; set; } = new HashSet<DeviceInventory>();
}
