namespace HospitalManagementSystem.DataProvider;

public class DefaultMappingProfile : Profile
{
    public DefaultMappingProfile()
    {
        AllowNullCollections = true;
        AllowNullDestinationValues = true;

        var guidRegex = new Regex(@"(?im)^[{(]?[0-9A-F]{8}[-]?(?:[0-9A-F]{4}[-]?){3}[0-9A-F]{12}[)}]?$");

        CreateMap<string, Guid>().ConvertUsing(x => string.IsNullOrWhiteSpace(x) ? Guid.NewGuid() : guidRegex.IsMatch(x) ? Guid.Parse(x) : Guid.NewGuid());
        CreateMap<string, Guid?>().ConvertUsing(x => string.IsNullOrWhiteSpace(x) ? null : Guid.Parse(x));

        CreateMap<Guid, string>().ConvertUsing(x => x.ToString());
        CreateMap<Guid?, string>().ConvertUsing(x => x.HasValue ? x.Value.ToString() : null!);


        CreateMap<Domain.BookingAppointment,   BookingAppointment>();
        CreateMap<Domain.ReExamAppointment,    ReExamAppointment>();
        CreateMap<Domain.Referral,             Referral>();
        CreateMap<Domain.ReferralDoctor,       ReferralDoctor>();

        CreateMap<BookingAppointment,   Domain.BookingAppointment>().ForMember(x => x.MedicalExam, opt => opt.Ignore());
        CreateMap<ReExamAppointment,    Domain.ReExamAppointment>().ForMember(x => x.MedicalExamEpisode, opt => opt.Ignore());
        CreateMap<Referral,             Domain.Referral>().ForMember(x => x.MedicalExam, opt => opt.Ignore());
        CreateMap<ReferralDoctor,       Domain.ReferralDoctor>().ForMember(x => x.Referral, opt => opt.Ignore())
                                                                 .ForMember(x => x.AssignmentHistory, opt => opt.Ignore());

        CreateMap<Domain.Department,       Department>();
        CreateMap<Domain.Room,             Room>();
        CreateMap<Domain.RoomAllocation,   RoomAllocation>();

        CreateMap<Department,       Domain.Department>();
        CreateMap<Room,             Domain.Room>().ForMember(x => x.Department, opt => opt.Ignore());
        CreateMap<RoomAllocation,   Domain.RoomAllocation>().ForMember(x => x.MedicalExamEpisode, opt => opt.Ignore())
                                                            .ForMember(x => x.Room, opt => opt.Ignore());

        CreateMap<Domain.Drug,             Drug>();
        CreateMap<Domain.DrugInventory,    DrugInventory>();
        CreateMap<Domain.DrugPrescription, DrugPrescription>();
        CreateMap<Domain.Storage,          Storage>();
        CreateMap<Domain.GoodSuppling,     GoodSuppling>();
        CreateMap<Domain.Importation,      Importation>();
        CreateMap<Domain.DeviceInventory,  DeviceInventory>();

        CreateMap<Drug,              Domain.Drug > ();
        CreateMap<DrugInventory,     Domain.DrugInventory >().ForMember(x => x.Drug, opt => opt.Ignore())
                                                            .ForMember(x => x.Importation, opt => opt.Ignore()) 
                                                            .ForMember(x => x.Storage, opt => opt.Ignore());
        CreateMap<DrugPrescription,  Domain.DrugPrescription >().ForMember(x => x.MedicalExamEpisode, opt => opt.Ignore())
                                                               .ForMember(x => x.DrugInventory, opt => opt.Ignore());
        CreateMap<Storage,           Domain.Storage >();
        CreateMap<Importation,       Domain.Importation >();
        CreateMap<DeviceInventory,   Domain.DeviceInventory >().ForMember(x => x.MedicalDevice, opt => opt.Ignore())
                                                              .ForMember(x => x.Storage, opt => opt.Ignore());

        CreateMap<Domain.AssignmentHistory,    AssignmentHistory>();
        CreateMap<Domain.Diagnosis,            Diagnosis>();
        CreateMap<Domain.DiagnosisTreatment,   DiagnosisTreatment>();
        CreateMap<Domain.Diseases,             Diseases>();
        CreateMap<Domain.ICDCode,              ICDCode>();
        CreateMap<Domain.ICDVersion,           ICDVersion>();
        CreateMap<Domain.ICDCodeVersion,       ICDCodeVersion>();
        CreateMap<Domain.MedicalExam,          MedicalExam>();
        CreateMap<Domain.MedicalExamEpisode,   MedicalExamEpisode>();
        CreateMap<Domain.Treatment,            Treatment>();


        CreateMap<AssignmentHistory,     Domain.AssignmentHistory >().ForMember(x => x.MedicalExamEpisode, opt => opt.Ignore())
                                                                    .ForMember(x => x.ReferralDoctor, opt => opt.Ignore());
        CreateMap<Diagnosis,             Domain.Diagnosis >().ForMember(x => x.ICDCode, opt => opt.Ignore())
                                                            .ForMember(x => x.MedicalExamEpisode, opt => opt.Ignore());
        CreateMap<DiagnosisTreatment,    Domain.DiagnosisTreatment >().ForMember(x => x.Treatment, opt => opt.Ignore())
                                                                     .ForMember(x => x.Diagnosis, opt => opt.Ignore());
        CreateMap<Diseases,              Domain.Diseases >();
        CreateMap<ICDCode,               Domain.ICDCode >().ForMember(x => x.Diseases, opt => opt.Ignore());
        CreateMap<ICDVersion,            Domain.ICDVersion >();
        CreateMap<ICDCodeVersion,        Domain.ICDCodeVersion >().ForMember(x => x.ICDCode, opt => opt.Ignore())
                                                                 .ForMember(x => x.ICDVersion, opt => opt.Ignore());
        CreateMap<MedicalExam,           Domain.MedicalExam >().ForMember(x => x.BookingAppointment, opt => opt.Ignore());
        CreateMap<MedicalExamEpisode,    Domain.MedicalExamEpisode >().ForMember(x => x.MedicalExam, opt => opt.Ignore())
                                                                     .ForMember(x => x.ReExamAppointment, opt => opt.Ignore())
                                                                     .ForMember(x => x.Bill, opt => opt.Ignore());
        CreateMap<Treatment, Domain.Treatment>();

        CreateMap<Domain.ServiceEpisode,   ServiceEpisode>();
        CreateMap<Domain.MedicalDevice,    MedicalDevice>();
        CreateMap<Domain.MedicalService,   MedicalService>();
        CreateMap<Domain.AnalysisTest,     AnalysisTest>();

        CreateMap<ServiceEpisode,    Domain.ServiceEpisode>().ForMember(x => x.MedicalExamEpisode, opt => opt.Ignore())
                                                             .ForMember(x => x.MedicalService, opt => opt.Ignore());
        CreateMap<MedicalDevice,    Domain.MedicalDevice>();
        CreateMap<MedicalService,   Domain.MedicalService>();
        CreateMap<AnalysisTest,     Domain.AnalysisTest>().ForMember(x => x.MedicalExamEpisode, opt => opt.Ignore())
                                                          .ForMember(x => x.DeviceInventory, opt => opt.Ignore());

        CreateMap<Domain.Bill, Bill>(); 
        
        CreateMap<Bill, Domain.Bill>().ForMember(x => x.MedicalExamEpisode, opt => opt.Ignore());
    }
}
