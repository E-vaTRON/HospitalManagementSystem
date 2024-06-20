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
        UserClaims = new();
        UserLogins = new();
        UserTokens = new();
        RoleClaims = new();

        Specializations = new();
        UserSpecializations = new();

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
    public List<Domain.UserClaim>   UserClaims  { get; private set; }
    public List<Domain.UserLogin>   UserLogins  { get; private set; }
    public List<Domain.UserToken>   UserTokens  { get; private set; }
    public List<Domain.RoleClaim>   RoleClaims  { get; private set; }

    public List<Domain.Specialization>      Specializations     { get; private set; }
    public List<Domain.UserSpecialization>  UserSpecializations { get; private set; }
    #endregion

    #region [ Private Methods ]
    private void Load()
    {
        LoadUsers();
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
    private void LoadUsers()
    {
        // Patients
        this.Users.Add(UserFactory.Create("patient1", "PATIENT1", 
                                          "patient1@hospital.com", "PATIENT1@HOSPITAL.COM", true, 
                                          "SECURITY_STAMP", "CONCURRENCY_STAMP", 
                                          "1234567891", true, false, true, 0, 
                                          "Patient", "1", 30, true, "123 Street", 
                                          "ID1", null, true)
                                  .AddPassword("12345"));

        this.Users.Add(UserFactory.Create("patient2", "PATIENT2", 
                                          "patient2@hospital.com", "PATIENT2@HOSPITAL.COM", true, 
                                          "SECURITY_STAMP", "CONCURRENCY_STAMP", 
                                          "1234567892", true, false, true, 0, 
                                          "Patient", "2", 30, true, "123 Street", 
                                          "ID2", null, true)
                                  .AddPassword("12345"));

        this.Users.Add(UserFactory.Create("patient3", "PATIENT3", 
                                          "patient3@hospital.com", "PATIENT3@HOSPITAL.COM", true, 
                                          "SECURITY_STAMP", "CONCURRENCY_STAMP", 
                                          "1234567893", true, false, true, 0, 
                                          "Patient", "3", 30, true, "123 Street", 
                                          "ID3", null, true)
                                  .AddPassword("12345"));

        this.Users.Add(UserFactory.Create("patient4", "PATIENT4", 
                                          "patient4@hospital.com", "PATIENT4@HOSPITAL.COM", true, 
                                          "SECURITY_STAMP", "CONCURRENCY_STAMP", 
                                          "1234567894", true, false, true, 0, 
                                          "Patient", "4", 30, true, "123 Street", 
                                          "ID4", null, true)
                                  .AddPassword("12345"));

        this.Users.Add(UserFactory.Create("patient5", "PATIENT5", 
                                          "patient5@hospital.com", "PATIENT5@HOSPITAL.COM", true, 
                                          "SECURITY_STAMP", "CONCURRENCY_STAMP", 
                                          "1234567895", true, false, true, 0, 
                                          "Patient", "5", 30, true, "123 Street", 
                                          "ID5", null, true)
                                  .AddPassword("12345"));

        this.Users.Add(UserFactory.Create("patient6", "PATIENT6", 
                                          "patient6@hospital.com", "PATIENT6@HOSPITAL.COM", true, 
                                          "SECURITY_STAMP", "CONCURRENCY_STAMP", 
                                          "1234567896", true, false, true, 0, 
                                          "Patient", "6", 30, true, "123 Street", 
                                          "ID6", null, true)
                                  .AddPassword("12345"));

        this.Users.Add(UserFactory.Create("patient7", "PATIENT7", 
                                          "patient7@hospital.com", "PATIENT7@HOSPITAL.COM", true, 
                                          "SECURITY_STAMP", "CONCURRENCY_STAMP", 
                                          "1234567897", true, false, true, 0, 
                                          "Patient", "7", 30, true, "123 Street", 
                                          "ID7", null, true)
                                  .AddPassword("12345"));

        this.Users.Add(UserFactory.Create("patient8", "PATIENT8", 
                                          "patient8@hospital.com", "PATIENT8@HOSPITAL.COM", true, 
                                          "SECURITY_STAMP", "CONCURRENCY_STAMP", 
                                          "1234567898", true, false, true, 0, 
                                          "Patient", "8", 30, true, "123 Street", 
                                          "ID8", null, true)
                                  .AddPassword("12345"));

        this.Users.Add(UserFactory.Create("patient9", "PATIENT9", 
                                          "patient9@hospital.com", "PATIENT9@HOSPITAL.COM", true, 
                                          "SECURITY_STAMP", "CONCURRENCY_STAMP", 
                                          "1234567899", true, false, true, 0, 
                                          "Patient", "9", 30, true, "123 Street", 
                                          "ID9", null, true)
                                  .AddPassword("12345"));

        this.Users.Add(UserFactory.Create("patient0", "PATIENT0", 
                                          "patient0@hospital.com", "PATIENT0@HOSPITAL.COM", true, 
                                          "SECURITY_STAMP", "CONCURRENCY_STAMP", 
                                          "1234567890", true, false, true, 0, 
                                          "Patient", "0", 30, true, "123 Street", 
                                          "ID0", null, true)
                                  .AddPassword("12345"));

        // Doctors
        this.Users.Add(UserFactory.Create("doctor1", "DOCTOR1", 
                                          "doctor1@hospital.com", "DOCTOR1@HOSPITAL.COM", true, 
                                          "SECURITY_STAMP", "CONCURRENCY_STAMP", 
                                          "2234567891", true, false, true, 0, 
                                          "Doctor", "1", 40, true, "456 Street", 
                                          "ID11", 5, true)
                                  .AddPassword("12345"));

        this.Users.Add(UserFactory.Create("doctor2", "DOCTOR2", 
                                          "doctor2@hospital.com", "DOCTOR2@HOSPITAL.COM", true, 
                                          "SECURITY_STAMP", "CONCURRENCY_STAMP", 
                                          "2234567892", true, false, true, 0, 
                                          "Doctor", "2", 40, true, "456 Street", 
                                          "ID12", 5, true)
                                  .AddPassword("12345"));

        // Nurses
        this.Users.Add(UserFactory.Create("nurse1", "NURSE1", 
                                          "nurse1@hospital.com", "NURSE1@HOSPITAL.COM", true, 
                                          "SECURITY_STAMP", "CONCURRENCY_STAMP", 
                                          "3234567891", true, false, true, 0, 
                                          "Nurse", "1", 35, false, "789 Street", 
                                          "ID13", 3, true)
                                  .AddPassword("12345"));

        this.Users.Add(UserFactory.Create("nurse2", "NURSE2", 
                                          "nurse2@hospital.com", "NURSE2@HOSPITAL.COM", true, 
                                          "SECURITY_STAMP", "CONCURRENCY_STAMP", 
                                          "3234567892", true, false, true, 0, 
                                          "Nurse", "2", 35, false, "789 Street", 
                                          "ID14", 3, true)
                                  .AddPassword("12345"));

        this.Users.Add(UserFactory.Create("nurse3", "NURSE3", 
                                          "nurse3@hospital.com", "NURSE3@HOSPITAL.COM", true, 
                                          "SECURITY_STAMP", "CONCURRENCY_STAMP", 
                                          "3234567893", true, false, true, 0, 
                                          "Nurse", "3", 35, false, "789 Street", 
                                          "ID15", 3, true)
                                  .AddPassword("12345"));

        this.Users.Add(UserFactory.Create("nurse4", "NURSE4", 
                                          "nurse4@hospital.com", "NURSE4@HOSPITAL.COM", true, 
                                          "SECURITY_STAMP", "CONCURRENCY_STAMP", 
                                          "3234567894", true, false, true, 0, 
                                          "Nurse", "4", 35, false, "789 Street", 
                                          "ID16", 3, true)
                                  .AddPassword("12345"));

        this.Users.Add(UserFactory.Create("nurse5", "NURSE5", 
                                          "nurse5@hospital.com", "NURSE5@HOSPITAL.COM", true, 
                                          "SECURITY_STAMP", "CONCURRENCY_STAMP", 
                                          "3234567895", true, false, true, 0, 
                                          "Nurse", "5", 35, false, "789 Street", 
                                          "ID17", 3, true)
                                  .AddPassword("12345"));

        this.Users.Add(UserFactory.Create("nurse6", "NURSE6", 
                                          "nurse6@hospital.com", "NURSE6@HOSPITAL.COM", true, 
                                          "SECURITY_STAMP", "CONCURRENCY_STAMP", 
                                          "3234567896", true, false, true, 0, 
                                          "Nurse", "6", 35, false, "789 Street", 
                                          "ID18", 3, true)
                                  .AddPassword("12345"));

        // Admin
        this.Users.Add(UserFactory.Create("admin", "ADMIN", 
                                          "admin@hospital.com", "ADMIN@HOSPITAL.COM", true, 
                                          "SECURITY_STAMP", "CONCURRENCY_STAMP", 
                                          "4234567890", true, false, true, 0, 
                                          "Admin", "User", 30, true, "Admin Street", 
                                          "ID19", null, true)
                                  .AddPassword("12345"));
    }

    private void LoadRole()
    {
        
    }
    #endregion
}
