namespace IdentitySystem.DataProvider;

public class Role : IdentityRole<Guid>, IModel<Guid>
{
    public bool         IsDeleted       { get; set; }
    public DateTime     CreatedOn       { get; set; } = DateTime.Now;
    public DateTime?    LastUpdatedOn   { get; set; }
    public DateTime?    DeleteOn        { get; set; }

    public virtual ICollection<UserRole>    UserRoles   { get; set; } = new HashSet<UserRole>();
    public virtual ICollection<RoleClaim>   RoleClaims  { get; set; } = new HashSet<RoleClaim>();
}