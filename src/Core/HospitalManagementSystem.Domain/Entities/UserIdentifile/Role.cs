namespace HospitalManagementSystem.Domain;

public class Role : BaseEntity
{
    public virtual ICollection<UserRole>    UserRoles   { get; } = new HashSet<UserRole>();
}
