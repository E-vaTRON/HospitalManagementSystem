namespace IdentitySystem.Tests;

public abstract class DataProviderTestBase
{
    #region [ Fields ]
    protected readonly IdentitySystemDbContext DbContext;
    protected readonly IServiceCollection ServiceCollection;
    protected readonly IServiceProvider ServiceProvider;
    protected readonly IMapper Mapper;
    protected readonly Fixture Fixture;
    #endregion

    #region [ CTors ]
    public DataProviderTestBase(string realConnection = "")
    {
        this.Fixture = new Fixture();
        Fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList()
                         .ForEach(b => Fixture.Behaviors.Remove(b));
        Fixture.Behaviors.Add(new OmitOnRecursionBehavior(recursionDepth: 1));
        Fixture.Customize(new FixtureCustomization());

        ServiceCollection = new ServiceCollection();

        ServiceCollection.AddSingleton<UserStoreProvider>()
                         .AddSingleton<RoleStoreProvider>();

        ServiceCollection.AddScoped<IUserManagerProvider, UserManagerProvider>()
                         .AddScoped<IRoleManagerProvider, RoleManagerProvider>();

        ServiceCollection.AddDbContext<IdentitySystemDbContext>((serviceProvider, optionsBuilder) =>
        {
            if (string.IsNullOrEmpty(realConnection))
            {
                optionsBuilder.UseInMemoryDatabase(Guid.NewGuid().ToString());
            }
            else
                optionsBuilder.UseSqlServer(realConnection);

            optionsBuilder.UseModel(SQLDatabaseModelBuilder.SQLModel.GetModel())
                          .EnableSensitiveDataLogging(true)
                          .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }, ServiceLifetime.Singleton);

        ServiceCollection.AddIdentity<Domain.User, Domain.Role>(options =>
        {
            options.Password.RequireDigit = false;
            options.Password.RequireLowercase = false;
            options.Password.RequireUppercase = false;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequiredLength = 1;
            options.User.RequireUniqueEmail = true;
        })
        .AddUserManager<UserManagerProvider>()
        .AddRoleManager<RoleManagerProvider>()
        .AddUserStore<UserStoreProvider>()
        .AddRoleStore<RoleStoreProvider>()
        .AddDefaultTokenProviders();

        ServiceCollection.AddLogging();

        ServiceCollection.AddScoped<IMapper>(option =>
        {
            var configuration = new MapperConfiguration(config =>
            {
                config.AllowNullCollections = true;
                config.AllowNullDestinationValues = true;

                var guidRegex = new Regex(@"(?im)^[{(]?[0-9A-F]{8}[-]?(?:[0-9A-F]{4}[-]?){3}[0-9A-F]{12}[)}]?$");

                config.CreateMap<string, Guid>().ConvertUsing(x => string.IsNullOrWhiteSpace(x) ? Guid.NewGuid() : guidRegex.IsMatch(x) ? Guid.Parse(x) : Guid.NewGuid());
                config.CreateMap<string, Guid?>().ConvertUsing(x => string.IsNullOrWhiteSpace(x) ? null : Guid.Parse(x));

                config.CreateMap<Guid, string>().ConvertUsing(x => x.ToString());
                config.CreateMap<Guid?, string>().ConvertUsing(x => x.HasValue ? x.Value.ToString() : null!);

                config.CreateMap<Domain.Notification, DataProvider.Notification>().ReverseMap();

                config.CreateMap<Domain.ScheduleDay, DataProvider.ScheduleDay>().ReverseMap();
                config.CreateMap<Domain.ScheduleSlot, DataProvider.ScheduleSlot>().ReverseMap();

                config.CreateMap<Domain.User, DataProvider.User>().ReverseMap();
                config.CreateMap<Domain.Role, DataProvider.Role>().ReverseMap();

                config.CreateMap<Domain.UserRole,       DataProvider.UserRole>().ReverseMap();
                config.CreateMap<Domain.UserClaim,      DataProvider.UserClaim>().ReverseMap();
                config.CreateMap<Domain.UserLogin,      DataProvider.UserLogin>().ReverseMap();
                config.CreateMap<Domain.UserToken,      DataProvider.UserToken>().ReverseMap();
                config.CreateMap<Domain.RoleClaim,      DataProvider.RoleClaim>().ReverseMap();

                config.CreateMap<Domain.UserSpecialization, DataProvider.UserSpecialization>().ReverseMap();
                config.CreateMap<Domain.Specialization,     DataProvider.Specialization>().ReverseMap();
            });

            return new Mapper(configuration);
        });

        ServiceProvider = ServiceCollection.BuildServiceProvider();

        var scope = ServiceProvider.CreateScope();
        DbContext = scope.ServiceProvider.GetRequiredService<IdentitySystemDbContext>();
        Mapper = ServiceProvider.GetRequiredService<IMapper>();

    }
    #endregion
}
