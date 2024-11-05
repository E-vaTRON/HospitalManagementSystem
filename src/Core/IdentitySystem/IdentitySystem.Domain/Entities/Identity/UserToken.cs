namespace IdentitySystem.Domain;

public class UserToken: IdentityUserToken<string>, IEntity<string>, IHasCreatedOn, IHasLastUpdatedOn, IHasDeleteOn
{
    public string       Id              { get; set; } = string.Empty;
    public bool         IsDeleted       { get; set; } = false;
    public DateTime     CreatedOn       { get; set; } = DateTime.Now;
    public DateTime?    LastUpdatedOn   { get; set; }
    public DateTime?    DeleteOn        { get; set; }

    public User User { get; set; } = default!;

    public UserToken()
    {
        Id = Guid.NewGuid().ToString();
        IsDeleted = false;
    }
}
