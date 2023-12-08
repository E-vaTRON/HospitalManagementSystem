namespace HospitalManagementSystem.Domain;

public class Department : EntityBase
{
    public string   Name    { get; set; } = string.Empty;
    public virtual ICollection<Room> Rooms { get; set; } = new HashSet<Room>();
}
