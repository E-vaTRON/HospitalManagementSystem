namespace IdentitySystem.DataProvider;

public class UserToken: IdentityUserToken<Guid>, IModel<Guid>
{
    public Guid         Id              { get; set; } = Guid.NewGuid();
    public bool         IsDeleted       { get; set; } = false;
    public DateTime     CreatedOn       { get; set; } = DateTime.Now;
    public DateTime?    LastUpdatedOn   { get; set; }
    public DateTime?    DeleteOn        { get; set; }

    public User User { get; set; } = default!;
}
