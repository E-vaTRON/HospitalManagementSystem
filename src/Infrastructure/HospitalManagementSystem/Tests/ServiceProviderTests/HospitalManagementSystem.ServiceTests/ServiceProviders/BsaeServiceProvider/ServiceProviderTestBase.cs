namespace HospitalManagementSystem.Tests;

public abstract class ServiceProviderTestBase
{
    #region [ Fields ]
    protected readonly IMapper Mapper;
    protected readonly Fixture Fixture;
    #endregion

    #region [ CTor ]
    public ServiceProviderTestBase()
    {
        this.Fixture = new Fixture();
        Fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList()
                         .ForEach(b => Fixture.Behaviors.Remove(b));
        Fixture.Behaviors.Add(new OmitOnRecursionBehavior(recursionDepth: 1));
        Fixture.Customize(new FixtureCustomization());

        var configuration = new MapperConfiguration(config =>
        {
            config.AllowNullCollections = true;
            config.AllowNullDestinationValues = true;

            var guidRegex = new Regex(@"(?im)^[{(]?[0-9A-F]{8}[-]?(?:[0-9A-F]{4}[-]?){3}[0-9A-F]{12}[)}]?$");

            config.CreateMap<string, Guid>().ConvertUsing(x => string.IsNullOrWhiteSpace(x) ? Guid.NewGuid() : guidRegex.IsMatch(x) ? Guid.Parse(x) : Guid.NewGuid());
            config.CreateMap<string, Guid?>().ConvertUsing(x => string.IsNullOrWhiteSpace(x) ? null : Guid.Parse(x));

            config.CreateMap<Guid, string>().ConvertUsing(x => x.ToString());
            config.CreateMap<Guid?, string>().ConvertUsing(x => x.HasValue ? x.Value.ToString() : null!);

            config.CreateMap<BookingAppointmentDTO ,    Domain.BookingAppointment>().ReverseMap();
            config.CreateMap<ReExamAppointmentDTO,      Domain.ReExamAppointment>().ReverseMap();
            config.CreateMap<ReferralDTO,               Domain.Referral>().ReverseMap();
            config.CreateMap<ReferralDoctorDTO,         Domain.ReferralDoctor>().ReverseMap();

            config.CreateMap<DepartmentDTO,     Domain.Department>().ReverseMap();
            config.CreateMap<RoomDTO,           Domain.Room>().ReverseMap();
            config.CreateMap<RoomAllocationDTO, Domain.RoomAllocation>().ReverseMap();
            //config.CreateMap<RoomAssignmentDTO, Domain.RoomAssignment>().ReverseMap();

            config.CreateMap<DrugDTO,               Domain.Drug>().ReverseMap();
            config.CreateMap<DrugInventoryDTO,      Domain.DrugInventory>().ReverseMap();
            config.CreateMap<DrugPrescriptionDTO,   Domain.DrugPrescription>().ReverseMap();
            config.CreateMap<StorageDTO,            Domain.Storage>().ReverseMap();
            config.CreateMap<GoodSupplingDTO,       Domain.GoodSuppling>().ReverseMap();
            config.CreateMap<ImportationDTO,        Domain.Importation>().ReverseMap();
            config.CreateMap<DeviceInventoryDTO,    Domain.DeviceInventory>().ReverseMap();

            config.CreateMap<AssignmentHistoryDTO,  Domain.AssignmentHistory>().ReverseMap();
            config.CreateMap<DiagnosisDTO,          Domain.Diagnosis>().ReverseMap();
            config.CreateMap<DiagnosisTreatmentDTO, Domain.DiagnosisTreatment>().ReverseMap();
            config.CreateMap<DiseasesDTO,           Domain.Diseases>().ReverseMap();
            config.CreateMap<ICDCodeDTO,            Domain.ICDCode>().ReverseMap();
            config.CreateMap<ICDVersionDTO,         Domain.ICDVersion>().ReverseMap();
            config.CreateMap<ICDCodeVersionDTO,     Domain.ICDCodeVersion>().ReverseMap();
            config.CreateMap<MedicalExamDTO,        Domain.MedicalExam>().ReverseMap();
            config.CreateMap<MedicalExamEpisodeDTO, Domain.MedicalExamEpisode>().ReverseMap();
            config.CreateMap<TreatmentDTO,          Domain.Treatment>().ReverseMap();

            config.CreateMap<DeviceServiceDTO,      Domain.DeviceService>().ReverseMap();
            config.CreateMap<MedicalDeviceDTO,      Domain.MedicalDevice>().ReverseMap();
            config.CreateMap<ServiceDTO,            Domain.Service>().ReverseMap();
            config.CreateMap<AnalysisTestDTO,       Domain.AnalysisTest>().ReverseMap();
        });
        Mapper = new Mapper(configuration);
    }
        #endregion
}
