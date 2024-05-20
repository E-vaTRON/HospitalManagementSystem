namespace IdentitySystem.Application;

public class UserDTO : DTOBase
{
    public string           UserName                { get; set; } = string.Empty;
    public string           NormalizedUserName      { get; set; } = string.Empty;
    public string           Email                   { get; set; } = string.Empty;
    public string           NormalizedEmail         { get; set; } = string.Empty;
    public bool             EmailConfirmed          { get; set; }
    public string           PasswordHash            { get; set; } = string.Empty;
    public string?          SecurityStamp           { get; set; }
    public string?          ConcurrencyStamp        { get; set; }
    public string?          PhoneNumber             { get; set; }
    public bool             PhoneNumberConfirmed    { get; set; }
    public bool             TwoFactorEnabled        { get; set; }
    public DateTimeOffset?  LockoutEnd              { get; set; }
    public bool             LockoutEnabled          { get; set; }
    public int              AccessFailedCount       { get; set; }

    public string       FirstName       { get; set; } = string.Empty;
    public string       LastName        { get; set; } = string.Empty;
    public int          Age             { get; set; }
    public DateTime     DayOfBirth      { get; set; }
    public bool         Gender          { get; set; }
    public string       Address         { get; set; } = string.Empty;
    public string       CardID          { get; set; } = string.Empty;
    public int?         SpecialistLevel { get; set; }
    public bool         Verified        { get; set; }

    public virtual ICollection<UserRoleDTO>         UserRoleDTOs        { get; set; } = new HashSet<UserRoleDTO>();
    public virtual ICollection<UserClaimDTO>        UserClaimDTOs       { get; set; } = new HashSet<UserClaimDTO>();
    public virtual ICollection<UserLoginDTO>        UserLoginDTOs       { get; set; } = new HashSet<UserLoginDTO>();
    public virtual ICollection<UserTokenDTO>        UserTokenDTOs       { get; set; } = new HashSet<UserTokenDTO>();
    public virtual ICollection<NotificationDTO>     NotificationDTOs    { get; set; } = new HashSet<NotificationDTO>();
    public virtual ICollection<SpecializationDTO>   SpecializationDTOs  { get; set; } = new HashSet<SpecializationDTO>();
    public virtual ICollection<ScheduleDayDTO>      ScheduleDayDTOs     { get; set; } = new HashSet<ScheduleDayDTO>();
}