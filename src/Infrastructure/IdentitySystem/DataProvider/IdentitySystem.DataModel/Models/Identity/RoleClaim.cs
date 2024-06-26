﻿namespace IdentitySystem.DataProvider;

public class RoleClaim : IdentityRoleClaim<Guid>, IModel<int>
{
    public bool         IsDeleted       { get; set; } = false;
    public DateTime     CreatedOn       { get; set; } = DateTime.Now;
    public DateTime?    LastUpdatedOn   { get; set; }
    public DateTime?    DeleteOn        { get; set; }

    public Role Role { get; set; } = default!;
}
