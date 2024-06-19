namespace HospitalManagementSystem.Tests;

public abstract class DataProviderTestBase
{
    #region [ Fields ]
    protected readonly HospitalManagementSystemDbContext DbContext;
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

        //var contextFactory = this.Fixture.Freeze<Mock<IDbContextFactory<HospitalManagementSystemDbContext>>>();
        var optionsBuilder = new DbContextOptionsBuilder<HospitalManagementSystemDbContext>().UseModel(SQLDatabaseModelBuilder.SQLModel.GetModel())
                                                                                             .EnableSensitiveDataLogging(true);

        if (string.IsNullOrEmpty(realConnection))
            optionsBuilder.UseInMemoryDatabase(Guid.NewGuid().ToString())
                          .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        else
            optionsBuilder.UseSqlServer(realConnection);

        var options = optionsBuilder.Options;

        DbContext = new HospitalManagementSystemDbContext(options);
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

            config.CreateMap<Domain.BookingAppointment, DataProvider.BookingAppointment>().ReverseMap();
            config.CreateMap<Domain.ReExamAppointment,  DataProvider.ReExamAppointment>().ReverseMap();
            config.CreateMap<Domain.Referral,           DataProvider.Referral>().ReverseMap();
            config.CreateMap<Domain.ReferralDoctor,     DataProvider.ReferralDoctor>().ReverseMap();

            config.CreateMap<Domain.Department,     DataProvider.Department>().ReverseMap();
            config.CreateMap<Domain.Room,           DataProvider.Room>().ReverseMap();
            config.CreateMap<Domain.RoomAllocation, DataProvider.RoomAllocation>().ReverseMap();
            //config.CreateMap<Domain.RoomAssignment, DataProvider.RoomAssignment>().ReverseMap();

            config.CreateMap<Domain.Drug,               DataProvider.Drug>().ReverseMap();
            config.CreateMap<Domain.DrugInventory,      DataProvider.DrugInventory>().ReverseMap();
            config.CreateMap<Domain.DrugPrescription,   DataProvider.DrugPrescription>().ReverseMap();
            config.CreateMap<Domain.Storage,            DataProvider.Storage>().ReverseMap();
            config.CreateMap<Domain.GoodSuppling,       DataProvider.GoodSuppling>().ReverseMap();
            config.CreateMap<Domain.Importation,        DataProvider.Importation>().ReverseMap();
            config.CreateMap<Domain.DeviceInventory,    DataProvider.DeviceInventory>().ReverseMap();

            config.CreateMap<Domain.AssignmentHistory,      DataProvider.AssignmentHistory>().ReverseMap();
            config.CreateMap<Domain.Diagnosis,              DataProvider.Diagnosis>().ReverseMap();
            config.CreateMap<Domain.DiagnosisTreatment,     DataProvider.DiagnosisTreatment>().ReverseMap();
            config.CreateMap<Domain.Diseases,               DataProvider.Diseases>().ReverseMap();
            config.CreateMap<Domain.ICDCode,                DataProvider.ICDCode>().ReverseMap();
            config.CreateMap<Domain.ICDVersion,             DataProvider.ICDVersion>().ReverseMap();
            config.CreateMap<Domain.ICDCodeVersion,         DataProvider.ICDCodeVersion>().ReverseMap();
            config.CreateMap<Domain.MedicalExam,            DataProvider.MedicalExam>().ReverseMap();
            config.CreateMap<Domain.MedicalExamEpisode,     DataProvider.MedicalExamEpisode>().ReverseMap();
            config.CreateMap<Domain.Treatment,              DataProvider.Treatment>().ReverseMap();
            config.CreateMap<Domain.TreatmentExamEpisode,   DataProvider.TreatmentExamEpisode>().ReverseMap();

            config.CreateMap<Domain.DeviceService,  DataProvider.DeviceService>().ReverseMap();
            config.CreateMap<Domain.MedicalDevice,  DataProvider.MedicalDevice>().ReverseMap();
            config.CreateMap<Domain.Service,        DataProvider.Service>().ReverseMap();
            config.CreateMap<Domain.AnalysisTest,   DataProvider.AnalysisTest>().ReverseMap();
        });
        Mapper = new Mapper(configuration);
    }
    #endregion [ CTors ]
}
