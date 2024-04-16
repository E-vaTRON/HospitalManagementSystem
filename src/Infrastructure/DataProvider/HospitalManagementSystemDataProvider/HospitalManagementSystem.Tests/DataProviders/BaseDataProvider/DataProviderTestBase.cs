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

            config.CreateMap<Domain.BookingAppointment, BookingAppointment>().ReverseMap();
            config.CreateMap<Domain.ReExamAppointment,  ReExamAppointment>().ReverseMap();
            config.CreateMap<Domain.Referral,           Referral>().ReverseMap();
            config.CreateMap<Domain.ReferralDoctor,     ReferralDoctor>().ReverseMap();

            config.CreateMap<Domain.Department,     Department>().ReverseMap();
            config.CreateMap<Domain.Room,           Room>().ReverseMap();
            config.CreateMap<Domain.RoomAllocation, RoomAllocation>().ReverseMap();
            config.CreateMap<Domain.RoomAssignment, RoomAssignment>().ReverseMap();

            config.CreateMap<Domain.Drug,               Drug>().ReverseMap();
            config.CreateMap<Domain.DrugInventory,      DrugInventory>().ReverseMap();
            config.CreateMap<Domain.DrugPrescription,   DrugPrescription>().ReverseMap();
            config.CreateMap<Domain.Storage,            Storage>().ReverseMap();
            config.CreateMap<Domain.GoodSuppling,       GoodSuppling>().ReverseMap();
            config.CreateMap<Domain.Importation,        Importation>().ReverseMap();
            config.CreateMap<Domain.DeviceInventory,    DeviceInventory>().ReverseMap();

            config.CreateMap<Domain.AssignmentHistory,      AssignmentHistory>().ReverseMap();
            config.CreateMap<Domain.Diagnosis,              Diagnosis>().ReverseMap();
            config.CreateMap<Domain.DiagnosisSuggestion,    DiagnosisSuggestion>().ReverseMap();
            config.CreateMap<Domain.DiagnosisTreatment,     DiagnosisTreatment>().ReverseMap();
            config.CreateMap<Domain.ICD,                    ICD>().ReverseMap();
            config.CreateMap<Domain.MedicalExam,            MedicalExam>().ReverseMap();
            config.CreateMap<Domain.MedicalExamEposode,     MedicalExamEposode>().ReverseMap();
            config.CreateMap<Domain.Treatment,              Treatment>().ReverseMap();
            config.CreateMap<Domain.TreatmentExamEpisode,   TreatmentExamEpisode>().ReverseMap();

            config.CreateMap<Domain.DeviceService,  DeviceService>().ReverseMap();
            config.CreateMap<Domain.MedicalDevice,  MedicalDevice>().ReverseMap();
            config.CreateMap<Domain.Service,        Service>().ReverseMap();
            config.CreateMap<Domain.AnalysisTest,   AnalysisTest>().ReverseMap();
        });
        Mapper = new Mapper(configuration);
    }
    #endregion [ CTors ]
}
