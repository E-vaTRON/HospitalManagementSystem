namespace IdentitySystem.DataProvider;

public class UserLogin : IdentityUserLogin<Guid>, IModel<Guid>
{
    public Guid         Id              { get; set; } = Guid.NewGuid();
    public bool         IsDeleted       { get; set; } = false;
    public DateTime     CreatedOn       { get; set; } = DateTime.Now;
    public DateTime?    LastUpdatedOn   { get; set; }
    public DateTime?    DeleteOn        { get; set; }
}
