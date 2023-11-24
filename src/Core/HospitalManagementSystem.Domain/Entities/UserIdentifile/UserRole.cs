namespace HospitalManagementSystem.Domain;

public class UserRole : BaseEntity
{
    public virtual User?    User    { get; set; }
    public virtual Role?    Role    { get; set; }
}
