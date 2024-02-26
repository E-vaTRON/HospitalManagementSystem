namespace HospitalManagementSystem.DataProvider;

public class User : IdentityUser
{
    public string       FirstName       { get; set; } = string.Empty;
    public string       LastName        { get; set; } = string.Empty;
    public int          Age             { get; set; }
    public DateTime     DayOfBirth      { get; set; }                   //ngày sinh
    public bool         Gender          { get; set; }                   //giới tính
    public string       Address         { get; set; } = string.Empty;   //địa chỉ
    public string       CardID          { get; set; } = string.Empty;   //mã thẻ
    public bool         Verified        { get; set; }
    public bool         IsDeleted       { get; set; } = false;
    public bool         IsExpired       { get; set; } = false;
    public DateTime     CreatedOn       { get; set; } = DateTime.Now;
    public DateTime?    LastUpdatedOn   { get; set; }
    public DateTime?    DeleteOn        { get; set; }

    public virtual ICollection<UserRole>    UserRoles   { get; set; } = new HashSet<UserRole>();
    public virtual ICollection<Alert>       Alerts      { get; set; } = new HashSet<Alert>();
}