namespace HospitalManagementSystem.Domain;

public class Specialization : EntityBase
{
    public string   Name        { get; set; } = string.Empty;
    public string?  Description { get; set; }

    public virtual ICollection<User> Users { get; set; } = new HashSet<User>();
}
