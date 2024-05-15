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

        ISpecializationDataProvider specializationDataProvider)
    {
        Notifications = notificationDataProvider;
        ScheduleDays = scheduleDayDataProvider;
        ScheduleSlots = scheduleSlotDataProvider;
        Users = userDataProvider;
        Roles = roleDataProvider;
        UserRoles = userRoleDataProvider;
        Specializations = specializationDataProvider;
    }
    #endregion

    #region [ Methods ]

    #region [  ]
    public INotificationDataProvider Notifications { get; set; }
    #endregion

    #region [  ]
    public IScheduleDayDataProvider ScheduleDays { get; set; }
    public IScheduleSlotDataProvider ScheduleSlots { get; set; }
    #endregion

    #region [  ]
    public IUserDataProvider Users { get; set; }
    public IRoleDataProvider Roles { get; set; }
    public IUserRoleDataProvider UserRoles { get; set; }
    #endregion

    #region [  ]
    public ISpecializationDataProvider Specializations { get; set; }
    #endregion
    #endregion
}
