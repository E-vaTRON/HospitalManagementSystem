﻿namespace HospitalManagementSystem.Domain;

public class User : IdentityUser, IHasCreatedOn, IHasLastUpdatedOn, IHasDeleteOn
{
    public string       FirstName       { get; set; } = string.Empty;
    public string       LastName        { get; set; } = string.Empty;
    public int          Age             { get; set; }                            
    public bool         IsDeleted       { get; set; } = false;
    public bool         IsExpired       { get; set; } = false;
    public DateTime     CreatedOn       { get; set; } = DateTime.Now;
    public DateTime?    LastUpdatedOn   { get; set; }
    public DateTime?    DeleteOn        { get; set; }

    public virtual ICollection<UserRole>    UserRoles   { get; set; } = new HashSet<UserRole>();
}