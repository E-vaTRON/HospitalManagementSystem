﻿namespace IdentitySystem.Domain;

public class User : IdentityUser<string>, IEntity<string>,  IHasCreatedOn, IHasLastUpdatedOn, IHasDeleteOn
{
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

    public virtual ICollection<UserRole>            UserRoles           { get; set; } = new HashSet<UserRole>();
    public virtual ICollection<UserClaim>           UserClaims          { get; set; } = new HashSet<UserClaim>();
    public virtual ICollection<UserLogin>           UserLogins          { get; set; } = new HashSet<UserLogin>();
    public virtual ICollection<UserToken>           UserTokens          { get; set; } = new HashSet<UserToken>();
    public virtual ICollection<Notification>        Notifications       { get; set; } = new HashSet<Notification>();
    public virtual ICollection<UserSpecialization>  UserSpecializations { get; set; } = new HashSet<UserSpecialization>();
    public virtual ICollection<ScheduleDay>         ScheduleDays        { get; set; } = new HashSet<ScheduleDay>();

    public User()
    {
        Id = Guid.NewGuid().ToString();
        IsDeleted = false;
    }
}