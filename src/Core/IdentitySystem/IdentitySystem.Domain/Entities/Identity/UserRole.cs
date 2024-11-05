namespace IdentitySystem.Domain;

public class UserRole : IdentityUserRole<string>, IEntity<string>, IHasCreatedOn, IHasLastUpdatedOn, IHasDeleteOn
{
    public string       Id              { get; set; } = string.Empty;
    public bool         IsDeleted       { get; set; } = false;
    public DateTime     CreatedOn       { get; set; } = DateTime.Now;
    public DateTime?    LastUpdatedOn   { get; set; }
    public DateTime?    DeleteOn        { get; set; }

    public virtual User? User { get; set; }
    public virtual Role? Role { get; set; }

    public UserRole() 
    {
        Id = Guid.NewGuid().ToString();
        IsDeleted = false;
    }
}