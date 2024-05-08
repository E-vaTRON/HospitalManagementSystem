namespace IdentitySystem.Domain;

public class Role : IdentityRole, IHasCreatedOn, IHasLastUpdatedOn, IHasDeleteOn
{
    public bool         IsDeleted       { get; set; }
    public DateTime     CreatedOn       { get; set; } = DateTime.Now;
    public DateTime?    LastUpdatedOn   { get; set; }
    public DateTime?    DeleteOn        { get; set; }
    public virtual ICollection<UserRole>    UserRoles   { get; } = new HashSet<UserRole>();
}