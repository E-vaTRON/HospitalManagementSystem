namespace IdentitySystem.Domain;

public class Specialization : EntityBase
{
    public string   Name        { get; set; } = string.Empty;
    public string?  Description { get; set; }

    public virtual ICollection<UserSpecialization> UserSpecializations { get; set; } = new HashSet<UserSpecialization>();
}
