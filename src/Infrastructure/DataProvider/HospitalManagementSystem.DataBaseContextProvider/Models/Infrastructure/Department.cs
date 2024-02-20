namespace HospitalManagementSystem.DataBaseContextProvider;

public class Department : ModelBase
{
    public string   Name    { get; set; } = string.Empty;
    public virtual ICollection<Room> Rooms { get; set; } = new HashSet<Room>();
}
