﻿namespace IdentitySystem.Domain;

public class RoleClaim : IdentityRoleClaim<string>, IEntity<int>, IHasCreatedOn, IHasLastUpdatedOn, IHasDeleteOn
{
    public bool         IsDeleted       { get; set; } = false;
    public DateTime     CreatedOn       { get; set; } = DateTime.Now;
    public DateTime?    LastUpdatedOn   { get; set; }
    public DateTime?    DeleteOn        { get; set; }

    public Role Role { get; set; } = default!;

    public RoleClaim()
    {
        IsDeleted = false;
    }
}
