namespace IdentitySystem.Domain;

public class UserLogin : IdentityUserLogin<string>, IEntity<string>, IHasCreatedOn, IHasLastUpdatedOn, IHasDeleteOn
{
    public string       Id              { get; set; } = string.Empty;
    public bool         IsDeleted       { get; set; } = false;
    public DateTime     CreatedOn       { get; set; } = DateTime.Now;
    public DateTime?    LastUpdatedOn   { get; set; }
    public DateTime?    DeleteOn        { get; set; }
}
