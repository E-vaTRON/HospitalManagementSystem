namespace HospitalManagementSystem.DataProvider;

public class Storage : ModelBase
{
    public string Location { get; set; } = string.Empty;

    public virtual ICollection<DrugInventory>   DrugInventories     { get; set; } = new HashSet<DrugInventory>();
    public virtual ICollection<DeviceInventory> DeviceInventories   { get; set; } = new HashSet<DeviceInventory>();
}
