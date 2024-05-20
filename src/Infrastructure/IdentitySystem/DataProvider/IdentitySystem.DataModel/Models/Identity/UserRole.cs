namespace IdentitySystem.DataProvider;

public class UserRole : IdentityUserRole<Guid>, IModel<Guid>
{
    public Guid         Id              { get; set; } = Guid.NewGuid();
    public bool         IsDeleted       { get; set; } = false;
    public DateTime     CreatedOn       { get; set; } = DateTime.Now;
    public DateTime?    LastUpdatedOn   { get; set; }
    public DateTime?    DeleteOn        { get; set; }

    public virtual User? User { get; set; }
    public virtual Role? Role { get; set; }
}