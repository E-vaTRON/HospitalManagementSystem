namespace IdentitySystem.DataProvider;

public class UserRole : IdentityUserRole<Guid>
{
    public Guid  Id { get; set; }

    public virtual User? User { get; set; }
    public virtual Role? Role { get; set; }
}