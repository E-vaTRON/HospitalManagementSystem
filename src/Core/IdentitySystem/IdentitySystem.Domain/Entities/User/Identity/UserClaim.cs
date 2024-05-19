namespace IdentitySystem.Domain;

public class UserClaim : IdentityUserClaim<string>, IEntity<int>, IHasCreatedOn, IHasLastUpdatedOn, IHasDeleteOn
{
    public bool         IsDeleted       { get; set; } = false;
    public DateTime     CreatedOn       { get; set; } = DateTime.Now;
    public DateTime?    LastUpdatedOn   { get; set; }
    public DateTime?    DeleteOn        { get; set; }
}
