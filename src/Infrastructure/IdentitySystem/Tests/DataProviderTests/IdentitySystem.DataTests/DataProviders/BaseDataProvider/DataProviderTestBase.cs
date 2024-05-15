namespace IdentitySystem.Tests;

public abstract class DataProviderTestBase
{
    #region [ Fields ]
    protected readonly IdentitySystemDbContext DbContext;
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

        //var contextFactory = this.Fixture.Freeze<Mock<IDbContextFactory<IdentitySystemDbContext>>>();
        var optionsBuilder = new DbContextOptionsBuilder<IdentitySystemDbContext>().UseModel(SQLDatabaseModelBuilder.SQLModel.GetModel())
                                                                                             .EnableSensitiveDataLogging(true);

        if (string.IsNullOrEmpty(realConnection))
            optionsBuilder.UseInMemoryDatabase(Guid.NewGuid().ToString())
                          .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        else
            optionsBuilder.UseSqlServer(realConnection);

        var options = optionsBuilder.Options;

        DbContext = new IdentitySystemDbContext(options);
        //DbContext.Certifications.AddRangeAsync(SeedProvider.Current.Certifications);
        //DbContext.SaveChangesAsync();

        //contextFactory.Setup(x => x.CreateDbContext())
        //              .Returns(() => DbContext);

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

            config.CreateMap<Domain.ScheduleDay,    DataProvider.ScheduleDay>().ReverseMap();
            config.CreateMap<Domain.ScheduleSlot,   DataProvider.ScheduleSlot>().ReverseMap();

            config.CreateMap<Domain.User,       DataProvider.User>().ReverseMap();
            config.CreateMap<Domain.Role,       DataProvider.Role>().ReverseMap();
            config.CreateMap<Domain.UserRole,   DataProvider.UserRole>().ReverseMap();

            config.CreateMap<Domain.Specialization, DataProvider.Specialization>().ReverseMap();
        });
        Mapper = new Mapper(configuration);
    }
    #endregion [ CTors ]
}
