﻿namespace IdentitySystem.Application;

public class DTOBase : DataObject<string>
{
    public bool         IsDeleted       { get; set; } = false;
    public DateTime     CreatedOn       { get; set; } = DateTime.Now;
    public DateTime?    LastUpdatedOn   { get; set; }
    public DateTime?    DeleteOn        { get; set; }

    public DTOBase()
    {
        Id = string.Empty;
        IsDeleted = false;
    }
}