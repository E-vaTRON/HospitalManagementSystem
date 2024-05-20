namespace IdentitySystem.DataProvider;

public class UserClaim : IdentityUserClaim<Guid>, IModel<int>
{
    public bool         IsDeleted       { get; set; } = false;
    public DateTime     CreatedOn       { get; set; } = DateTime.Now;
    public DateTime?    LastUpdatedOn   { get; set; }
    public DateTime?    DeleteOn        { get; set; }

    public User User { get; set; } = default!;
}
