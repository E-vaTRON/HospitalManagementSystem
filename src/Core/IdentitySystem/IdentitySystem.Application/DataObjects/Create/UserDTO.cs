namespace IdentitySystem.Application;

public class UserDTO
{
    public string       Id              { get; set; } = string.Empty;
    public string       UserName        { get; set; } = string.Empty;
    public string       FirstName       { get; set; } = string.Empty;
    public string       LastName        { get; set; } = string.Empty;
    public int          Age             { get; set; }
    public DateTime     DayOfBirth      { get; set; }                   //ngày sinh
    public bool         Gender          { get; set; }                   //giới tính
    public string       Address         { get; set; } = string.Empty;   //địa chỉ
    public string       CardID          { get; set; } = string.Empty;   //mã thẻ ???
    public int?         SpecialistLevel { get; set; }                   //có bác sĩ là có thôi
    public bool         Verified        { get; set; }
    public bool         IsDeleted       { get; set; } = false;
    public bool         IsExpired       { get; set; } = false;
    public DateTime     CreatedOn       { get; set; } = DateTime.Now;
    public DateTime?    LastUpdatedOn   { get; set; }
    public DateTime?    DeleteOn        { get; set; }
}
