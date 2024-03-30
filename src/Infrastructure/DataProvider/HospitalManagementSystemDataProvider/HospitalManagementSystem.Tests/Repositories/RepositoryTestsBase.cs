namespace HospitalManagementSystem.Tests;

public abstract class RepositoryTestsBase
{
    #region [ Fields ]
    protected readonly HospitalManagementSystemDbContext dbContext;

    protected readonly IMapper mapper;
    #endregion

    #region [ CTors ]
    public RepositoryTestsBase(string realConnection = "")
    {
        var dbOptionsBuilder = new DbContextOptionsBuilder<HospitalManagementSystemDbContext>();

        if (string.IsNullOrEmpty(realConnection))
            dbOptionsBuilder.UseInMemoryDatabase(Guid.NewGuid().ToString());
        else
            dbOptionsBuilder.UseSqlServer(realConnection);

        var dbOptions = dbOptionsBuilder.Options;

        dbContext = new HospitalManagementSystemDbContext(dbOptions);

        var configuration = new MapperConfiguration(config =>
        {
            config.AllowNullCollections = true;
            config.AllowNullDestinationValues = true;

            var guidRegex = new Regex(@"(?im)^[{(]?[0-9A-F]{8}[-]?(?:[0-9A-F]{4}[-]?){3}[0-9A-F]{12}[)}]?$");

            config.CreateMap<string, Guid>().ConvertUsing(x => string.IsNullOrWhiteSpace(x) ? Guid.NewGuid() : guidRegex.IsMatch(x) ? Guid.Parse(x) : Guid.NewGuid());
            config.CreateMap<string, Guid?>().ConvertUsing(x => string.IsNullOrWhiteSpace(x) ? null : Guid.Parse(x));

            config.CreateMap<Guid, string>().ConvertUsing(x => x.ToString());
            config.CreateMap<Guid?, string>().ConvertUsing(x => x.HasValue ? x.Value.ToString() : null!);

            config.CreateMap<Domain.Alert,              Alert>().ReverseMap();
            config.CreateMap<Domain.BookingAppointment, BookingAppointment>().ReverseMap();
            config.CreateMap<Domain.ReExamAppointment,  ReExamAppointment>().ReverseMap();
            config.CreateMap<Domain.Referral,           Referral>().ReverseMap();
            config.CreateMap<Domain.ScheduleDay,        ScheduleDay>().ReverseMap();
            config.CreateMap<Domain.ScheduleSlot,       ScheduleSlot>().ReverseMap();

            config.CreateMap<Domain.Department,     Department>().ReverseMap();
            config.CreateMap<Domain.Room,           Room>().ReverseMap();
            config.CreateMap<Domain.RoomAllocation, RoomAllocation>().ReverseMap();
            config.CreateMap<Domain.RoomAssignment, RoomAssignment>().ReverseMap();

            config.CreateMap<Domain.Drug,               Drug>().ReverseMap();
            config.CreateMap<Domain.DrugInventory,      DrugInventory>().ReverseMap();
            config.CreateMap<Domain.Storage,            Storage>().ReverseMap();
            config.CreateMap<Domain.GoodSuppling,       GoodSuppling>().ReverseMap();
            config.CreateMap<Domain.Importation,        Importation>().ReverseMap();
            config.CreateMap<Domain.DeviceInventory,    DeviceInventory>().ReverseMap();

            config.CreateMap<Domain.Diagnosis,              Diagnosis>().ReverseMap();
            config.CreateMap<Domain.DiagnosisSuggestion,    DiagnosisSuggestion>().ReverseMap();
            config.CreateMap<Domain.ICD,                    ICD>().ReverseMap();
            config.CreateMap<Domain.ICDD,                   ICDD>().ReverseMap();
            config.CreateMap<Domain.MedicalExam,            MedicalExam>().ReverseMap();
            config.CreateMap<Domain.MedicalExamEposode,     MedicalExamEposode>().ReverseMap();
            config.CreateMap<Domain.Treatment,              Treatment>().ReverseMap();

            config.CreateMap<Domain.DeviceService,  DeviceService>().ReverseMap();
            config.CreateMap<Domain.MedicalDevice,  MedicalDevice>().ReverseMap();
            config.CreateMap<Domain.Service,        Service>().ReverseMap();
            config.CreateMap<Domain.AnalysisTest,   AnalysisTest>().ReverseMap();

            config.CreateMap<Domain.Bill,           Bill>().ReverseMap();
            config.CreateMap<Domain.DrugBillDetail, DrugBillDetail>().ReverseMap();
            config.CreateMap<Domain.Transaction,    Transaction>().ReverseMap();
        });
        mapper = new Mapper(configuration);
    }
    #endregion [ CTors ]
}
