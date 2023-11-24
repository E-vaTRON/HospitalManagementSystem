namespace HospitalManagementSystem.DataBaseContextProvider;

public class Storage : BaseModel<Guid>
{
    public string location { get; set; } = string.Empty;

    public virtual ICollection<Inventory> Inventories { get; set; } = new HashSet<Inventory>();
}
