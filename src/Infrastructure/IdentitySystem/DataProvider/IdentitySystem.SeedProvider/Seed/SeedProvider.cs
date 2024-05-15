namespace IdentitySystem.DataProvider;

public class SeedProvider
{
    #region [ Singleton ]
    private static readonly Lazy<SeedProvider> seed = new Lazy<SeedProvider>(() => new SeedProvider(), LazyThreadSafetyMode.PublicationOnly);
    public static SeedProvider Seed
    {
        get { return seed.Value; }
    }
    #endregion

    #region [ CTor ]
    public SeedProvider()
    {
        // init
        Notifications = new();

        ScheduleDays = new();
        ScheduleSlots = new();

        Users = new();
        Roles = new();
        UserRoles = new();

        Specializations = new();

        Clear();
        Load();
    }
    #endregion

    #region [ Properties ]
    public List<Domain.Notification> Notifications { get; private set; }

    public List<Domain.ScheduleDay>     ScheduleDays    { get; private set; }
    public List<Domain.ScheduleSlot>    ScheduleSlots   { get; private set; }

    public List<Domain.User>        Users       { get; private set; }
    public List<Domain.Role>        Roles       { get; private set; }
    public List<Domain.UserRole>    UserRoles   { get; private set; }

    public List<Domain.Specialization> Specializations { get; private set; }
    #endregion

    #region [ Private Methods ]
    private void Load()
    {
    }

    private void Clear()
    {
        Notifications.Clear();

        ScheduleDays.Clear();
        ScheduleSlots.Clear();

        Users.Clear();
        Roles.Clear();
        UserRoles.Clear();

        Specializations.Clear();
    }
    #endregion

    #region [ Seed Create ]
    
    #endregion
}
