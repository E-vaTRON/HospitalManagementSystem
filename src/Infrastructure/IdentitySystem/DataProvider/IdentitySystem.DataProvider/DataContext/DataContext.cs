namespace IdentitySystem.DataProvider;

public class DataContext
{
    #region [ CTor ]
    public DataContext(
        INotificationDataProvider notificationDataProvider,

        IScheduleDayDataProvider scheduleDayDataProvider,
        IScheduleSlotDataProvider scheduleSlotDataProvider,

        IUserDataProvider userDataProvider,
        IRoleDataProvider roleDataProvider,
        IUserRoleDataProvider userRoleDataProvider,
        IUserClaimDataProvider userClaimDataProvider,
        IUserLoginDataProvider userLoginDataProvider,
        IUserTokenDataProvider userTokenDataProvider,
        IRoleClaimDataProvider roleClaimDataProvider,

        ISpecializationDataProvider specializationDataProvider,
        IUserSpecializationDataProvider userSpecializationDataProvider)
    {
        Notifications = notificationDataProvider;
        ScheduleDays = scheduleDayDataProvider;
        ScheduleSlots = scheduleSlotDataProvider;
        Users = userDataProvider;
        Roles = roleDataProvider;
        UserRoles = userRoleDataProvider;
        UserClaims = userClaimDataProvider;
        UserLogins = userLoginDataProvider;
        UserTokens = userTokenDataProvider;
        RoleClaims = roleClaimDataProvider;
        Specializations = specializationDataProvider;
        UserSpecializations = userSpecializationDataProvider;
    }
    #endregion

    #region [ Methods ]

    #region [ Notification ]
    public INotificationDataProvider Notifications { get; set; }
    #endregion

    #region [ Schedule ]
    public IScheduleDayDataProvider ScheduleDays { get; set; }
    public IScheduleSlotDataProvider ScheduleSlots { get; set; }
    #endregion

    #region [ Identity ]
    public IUserDataProvider        Users       { get; set; }
    public IRoleDataProvider        Roles       { get; set; }
    public IUserRoleDataProvider    UserRoles   { get; set; }
    public IUserClaimDataProvider   UserClaims  { get; set; }
    public IUserLoginDataProvider   UserLogins  { get; set; }
    public IUserTokenDataProvider   UserTokens  { get; set; }
    public IRoleClaimDataProvider   RoleClaims  { get; set; }
    #endregion

    #region [ Specialization ]
    public ISpecializationDataProvider      Specializations     { get; set; }
    public IUserSpecializationDataProvider  UserSpecializations { get; set; }
    #endregion
    #endregion
}
