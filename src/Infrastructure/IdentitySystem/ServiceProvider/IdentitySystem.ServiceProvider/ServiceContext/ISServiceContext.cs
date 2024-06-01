namespace IdentitySystem.ServiceProvider;

public class ISServiceContext
{
    #region [ CTor ]
    public ISServiceContext(
        INotificationServiceProvider notificationServiceProvider,

        IScheduleDayServiceProvider  scheduleDayServiceProvider,
        IScheduleSlotServiceProvider scheduleSlotDataProvider,

        IUserServiceProvider  userServiceProvider,
        IRoleServiceProvider  roleServiceProvider,

        IUserRoleServiceProvider  userRoleServiceProvider,
        IUserClaimServiceProvider userClaimServiceProvider,
        IUserLoginServiceProvider userLoginServiceProvider,
        IUserTokenServiceProvider userTokenServiceProvider,
        IRoleClaimServiceProvider roleClaimServiceProvider,

        IUserSpecializationServiceProvider userSpecializationServiceProvider,
        ISpecializationServiceProvider specializationServiceProvider
        )
    {
        Notifications = notificationServiceProvider;

        ScheduleDays = scheduleDayServiceProvider;
        ScheduleSlots = scheduleSlotDataProvider;

        Users = userServiceProvider;
        Roles = roleServiceProvider;

        UserClaims = userClaimServiceProvider;
        UserLogins = userLoginServiceProvider;
        UserTokens = userTokenServiceProvider;
        RoleClaims = roleClaimServiceProvider;
        UserRoles = userRoleServiceProvider;

        UserSpecializations = userSpecializationServiceProvider;
        Specializations = specializationServiceProvider;
    }
    #endregion

    #region [ Methods ]
    #region [ Notification ]
    public INotificationServiceProvider Notifications { get; set; }
    #endregion

    #region [ Schedule ]
    public IScheduleDayServiceProvider  ScheduleDays    { get; set; }
    public IScheduleSlotServiceProvider ScheduleSlots   { get; set; }
    #endregion

    #region [ User ]
    public IUserServiceProvider Users   { get; set; }
    public IRoleServiceProvider Roles   { get; set; }
    #endregion

    #region [ Identity ]
    public IUserRoleServiceProvider     UserRoles   { get; set; }
    public IUserClaimServiceProvider    UserClaims  { get; set; }
    public IUserLoginServiceProvider    UserLogins  { get; set; }
    public IUserTokenServiceProvider    UserTokens  { get; set; }
    public IRoleClaimServiceProvider    RoleClaims  { get; set; }
    #endregion

    #region [ Specialization ]
    public IUserSpecializationServiceProvider   UserSpecializations { get; set; }
    public ISpecializationServiceProvider       Specializations     { get; set; }
    #endregion
    #endregion
}
