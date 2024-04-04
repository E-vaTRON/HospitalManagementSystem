namespace HospitalManagementSystem.DataProvider;

public class Specialization : ModelBase
{
    public string   Name        { get; set; } = string.Empty;
    public string?  Description { get; set; }

    public virtual ICollection<User> Users { get; set; } = new HashSet<User>();
}
