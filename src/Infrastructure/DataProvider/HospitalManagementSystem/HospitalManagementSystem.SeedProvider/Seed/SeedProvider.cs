namespace HospitalManagementSystem.DataProvider;

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
        BookingAppointments = new();
        ReExamAppointments = new();
        Referrals = new();
        ReferralDoctors = new();

        Departments = new();
        Rooms = new();
        RoomAllocations = new();
        RoomAssignments = new();

        Drugs = new();
        DrugInventorys = new();
        DrugPrescriptions = new();
        Storages = new();
        GoodSupplings = new();
        Importations = new();
        DeviceInventorys = new();

        AssignmentHistories = new();
        Diagnoses = new();
        ICDs = new();
        MedicalExams = new();
        MedicalExamEposodes = new();
        Treatments = new();
        TreatmentExamEpisodes = new();

        DeviceServices = new();
        MedicalDevices = new();
        Services = new();
        AnalysisTests = new();

        this.Clear();
        this.Load();
    }
    #endregion

    #region [ Properties ]
    //public virtual DbSet<AppointmentBase>       AppointmentBases    { get; set; } = null!;
    public List<Domain.BookingAppointment>    BookingAppointments { get; private set; }
    public List<Domain.ReExamAppointment>     ReExamAppointments  { get; private set; }
    public List<Domain.Referral>              Referrals           { get; private set; }
    public List<Domain.ReferralDoctor>        ReferralDoctors     { get; private set; }

    public List<Domain.Department>        Departments     { get; private set; }
    public List<Domain.Room>              Rooms           { get; private set; }
    public List<Domain.RoomAllocation>    RoomAllocations { get; private set; }
    public List<Domain.RoomAssignment>    RoomAssignments { get; private set; }

    public List<Domain.Drug>              Drugs               { get; private set; }
    public List<Domain.DrugInventory>     DrugInventorys      { get; private set; }
    public List<Domain.DrugPrescription>  DrugPrescriptions   { get; private set; }
    public List<Domain.Storage>           Storages            { get; private set; }
    public List<Domain.GoodSuppling>      GoodSupplings       { get; private set; }
    public List<Domain.Importation>       Importations        { get; private set; }
    public List<Domain.DeviceInventory>   DeviceInventorys    { get; private set; }

    public List<Domain.AssignmentHistory>     AssignmentHistories     { get; private set; }
    public List<Domain.Diagnosis>             Diagnoses               { get; private set; }
    //public virtual DbSet<DiagnosisSuggestion>   DiagnosisSuggestions    { get; set; }
    public List<Domain.Diseases>                   ICDs                    { get; private set; }
    public List<Domain.MedicalExam>           MedicalExams            { get; private set; }
    public List<Domain.MedicalExamEposode>    MedicalExamEposodes     { get; private set; }
    public List<Domain.Treatment>             Treatments              { get; private set; }
    public List<Domain.TreatmentExamEpisode>  TreatmentExamEpisodes   { get; private set; }

    public List<Domain.DeviceService>     DeviceServices  { get; private set; }
    public List<Domain.MedicalDevice>     MedicalDevices  { get; private set; }
    public List<Domain.Service>           Services        { get; private set; }
    public List<Domain.AnalysisTest>      AnalysisTests   { get; private set; }
    #endregion

    #region [ Private Methods ]
    private void Load()
    {
        LoadICDs();
    }

    private void Clear()
    {
        BookingAppointments.Clear();
        ReExamAppointments.Clear();
        Referrals.Clear();
        ReferralDoctors.Clear();

        Departments.Clear();
        Rooms.Clear();
        RoomAllocations.Clear();
        RoomAssignments.Clear();

        Drugs.Clear();
        DrugInventorys.Clear();
        DrugPrescriptions.Clear();
        Storages.Clear();
        GoodSupplings.Clear();
        Importations.Clear();
        DeviceInventorys.Clear();

        AssignmentHistories.Clear();
        Diagnoses.Clear();
        ICDs.Clear();
        MedicalExams.Clear();
        MedicalExamEposodes.Clear();
        Treatments.Clear();
        TreatmentExamEpisodes.Clear();

        DeviceServices.Clear();
        MedicalDevices.Clear();
        Services.Clear();
        AnalysisTests.Clear();
    }
    #endregion

    #region [ Seed Create ]
    private void LoadICDs()
    {
        ICDs.Add(ICDFactory.Create("A52.74", "Syphilis of liver and other viscera", Domain.CodeStatus.Active));
        ICDs.Add(ICDFactory.Create("B18.2", "Chronic viral hepatitis C", Domain.CodeStatus.Active));
        ICDs.Add(ICDFactory.Create("C22.9", "Malignant neoplasm of liver, not specified as primary or secondary", Domain.CodeStatus.Active));
        ICDs.Add(ICDFactory.Create("C56.9", "Malignant neoplasm of unspecified ovary", Domain.CodeStatus.Active));
        ICDs.Add(ICDFactory.Create("E78.2", "Mixed hyperlipidemia", Domain.CodeStatus.Active));
        ICDs.Add(ICDFactory.Create("E83.19", "Other disorders of iron metabolism", Domain.CodeStatus.Active));
        ICDs.Add(ICDFactory.Create("E84.9", "Cystic fibrosis, unspecified", Domain.CodeStatus.Active));
        ICDs.Add(ICDFactory.Create("D64.3", "Other sideroblastic anemias", Domain.CodeStatus.Active));
        ICDs.Add(ICDFactory.Create("K70.30", "Alcoholic cirrhosis of liver without ascites", Domain.CodeStatus.Active));
        ICDs.Add(ICDFactory.Create("K73.9", "Chronic hepatitis, unspecified", Domain.CodeStatus.Active));
        ICDs.Add(ICDFactory.Create("K74.60", "Unspecified cirrhosis of liver", Domain.CodeStatus.Active));
        ICDs.Add(ICDFactory.Create("R97.8", "Other abnormal tumor markers", Domain.CodeStatus.Active));
        ICDs.Add(ICDFactory.Create("C18.9", "Malignant neoplasm of colon, unspecified", Domain.CodeStatus.Active));
        ICDs.Add(ICDFactory.Create("C20", "Malignant neoplasm of rectum", Domain.CodeStatus.Active));
        ICDs.Add(ICDFactory.Create("C26.0", "Malignant neoplasm of intestinal tract, part unspecified", Domain.CodeStatus.Active));
        ICDs.Add(ICDFactory.Create("C34.90", "Malignant neoplasm of unspecified part of unspecified bronchus or lung", Domain.CodeStatus.Active));
        ICDs.Add(ICDFactory.Create("C50.919", "Malignant neoplasm of unspecified site of unspecified female breast", Domain.CodeStatus.Active));
        ICDs.Add(ICDFactory.Create("C56.9", "Malignant neoplasm of unspecified ovary", Domain.CodeStatus.Active));
        ICDs.Add(ICDFactory.Create("R78.9", "Finding of unspecified substance, not normally found in blood", Domain.CodeStatus.Active));
        ICDs.Add(ICDFactory.Create("R79.89", "Other specified abnormal findings of blood chemistry", Domain.CodeStatus.Active));
        ICDs.Add(ICDFactory.Create("R97.0", "Elevated carcinoembryonic antigen [CEA]", Domain.CodeStatus.Active));
        ICDs.Add(ICDFactory.Create("R97.8", "Other abnormal tumor markers", Domain.CodeStatus.Active));
        ICDs.Add(ICDFactory.Create("Z85.3", "Personal history of malignant neoplasm of breast", Domain.CodeStatus.Active));
        ICDs.Add(ICDFactory.Create("Z85.43", "Personal history of malignant neoplasm of ovary", Domain.CodeStatus.Active));
        ICDs.Add(ICDFactory.Create("C53.0", "Malignant neoplasm of endocervix", Domain.CodeStatus.Active));
        ICDs.Add(ICDFactory.Create("C54.9", "Malignant neoplasm of corpus uteri, unspecified", Domain.CodeStatus.Active));
        ICDs.Add(ICDFactory.Create("C56.9", "Malignant neoplasm of unspecified ovary", Domain.CodeStatus.Active));
        ICDs.Add(ICDFactory.Create("C57.00", "Malignant neoplasm of unspecified fallopian tube", Domain.CodeStatus.Active));
        ICDs.Add(ICDFactory.Create("C57.4", "Malignant neoplasm of uterine adnexa, unspecified", Domain.CodeStatus.Active));
        ICDs.Add(ICDFactory.Create("C79.60", "Secondary malignant neoplasm of unspecified ovary", Domain.CodeStatus.Active));
    }


    #endregion
}
