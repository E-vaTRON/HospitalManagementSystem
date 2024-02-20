namespace HospitalManagementSystem.DataBaseContextProvider;

public class UserRole : IdentityUserRole<string>
{
    public DateTime     CreatedOn       { get; set; } = DateTime.Now;
    public DateTime?    LastUpdatedOn   { get; set; }
    public DateTime?    DeleteOn        { get; set; }

    public virtual User?    User    { get; set; }
    public virtual Role?    Role    { get; set; }
}