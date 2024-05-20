namespace IdentitySystem.DataProvider;

public class Specialization : ModelBase
{
    public string   Name        { get; set; } = string.Empty;
    public string?  Description { get; set; }

    public virtual ICollection<UserSpecialization> UserSpecializations { get; set; } = new HashSet<UserSpecialization>();
}
