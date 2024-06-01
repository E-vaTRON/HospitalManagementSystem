namespace HospitalManagementSystem.DataProvider;

public partial class HospitalManagementSystemDbContext : DbContext
{
    #region [ CTor ]
    public HospitalManagementSystemDbContext(DbContextOptions<HospitalManagementSystemDbContext> options) : base(options)
    {
        base.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        base.ChangeTracker.AutoDetectChangesEnabled = false;
    }
    #endregion

    #region [ Override ]
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
    #endregion

    #region [ Properties ]
    //public virtual DbSet<AppointmentBase>       AppointmentBases    { get; set; } = null!;
    public virtual DbSet<BookingAppointment>    BookingAppointments { get; set; } = null!;
    public virtual DbSet<ReExamAppointment>     ReExamAppointments  { get; set; } = null!;
    public virtual DbSet<Referral>              Referrals           { get; set; } = null!;
    public virtual DbSet<ReferralDoctor>        ReferralDoctors     { get; set; } = null!;

    public virtual DbSet<Department>        Departments     { get; set; } = null!;
    public virtual DbSet<Room>              Rooms           { get; set; } = null!;
    public virtual DbSet<RoomAllocation>    RoomAllocations { get; set; } = null!;
    public virtual DbSet<RoomAssignment>    RoomAssignments { get; set; } = null!;

    public virtual DbSet<Drug>              Drugs               { get; set; } = null!;
    public virtual DbSet<DrugInventory>     DrugInventorys      { get; set; } = null!;
    public virtual DbSet<DrugPrescription>  DrugPrescriptions   { get; set; } = null!;
    public virtual DbSet<Storage>           Storages            { get; set; } = null!;
    //public virtual DbSet<GoodSuppling>      GoodSupplings       { get; set; } = null!;
    public virtual DbSet<Importation>       Importations        { get; set; } = null!;
    public virtual DbSet<DeviceInventory>   DeviceInventorys    { get; set; } = null!;

    public virtual DbSet<AssignmentHistory>     AssignmentHistories     { get; set; } = null!;
    public virtual DbSet<Diagnosis>             Diagnoses               { get; set; } = null!;
    //public virtual DbSet<DiagnosisSuggestion>   DiagnosisSuggestions    { get; set; } = null!;
    public virtual DbSet<DiagnosisTreatment>    DiagnosisTreatments     { get; set; } = null!;
    public virtual DbSet<Diseases>              Diseases                { get; set; } = null!;
    public virtual DbSet<ICDCode>               ICDCodes                { get; set; } = null!;
    public virtual DbSet<ICDCodeVersion>        ICDCodeVersions         { get; set; } = null!;
    public virtual DbSet<ICDVersion>            ICDVersions             { get; set; } = null!;
    public virtual DbSet<MedicalExam>           MedicalExams            { get; set; } = null!;
    public virtual DbSet<MedicalExamEpisode>    MedicalExamEpisodes     { get; set; } = null!;
    public virtual DbSet<Treatment>             Treatments              { get; set; } = null!; 
    //public virtual DbSet<TreatmentExamEpisode>  TreatmentExamEpisodes   { get; set; } = null!;

    public virtual DbSet<DeviceService>     DeviceServices  { get; set; } = null!;
    public virtual DbSet<MedicalDevice>     MedicalDevices  { get; set; } = null!;
    public virtual DbSet<Service>           Services        { get; set; } = null!;
    public virtual DbSet<AnalysisTest>      AnalysisTests   { get; set; } = null!;

    public virtual DbSet<Bill>              Bills           { get; set; } = null!;
    #endregion
}
