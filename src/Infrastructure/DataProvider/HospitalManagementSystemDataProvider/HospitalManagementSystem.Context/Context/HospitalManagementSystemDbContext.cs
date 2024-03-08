namespace HospitalManagementSystem.DataProvider;

public class HospitalManagementSystemDbContext : DbContext
{
    public HospitalManagementSystemDbContext(DbContextOptions options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }

    public virtual DbSet<Alert>                 Alerts                  { get; set; } = null!;
    public virtual DbSet<AppointmentBase>       AppointmentBases        { get; set; } = null!;
    //public virtual DbSet<BookingAppointment>    BookingAppointments     { get; set; } = null!;
    //public virtual DbSet<ReExamAppointment>     ReExamAppointments      { get; set; } = null!;
    public virtual DbSet<Referral>              Referrals               { get; set; } = null!;
    public virtual DbSet<EmployeeSchedule>      EmployeeSchedules       { get; set; } = null!;
    public virtual DbSet<Department>            Departments             { get; set; } = null!;
    public virtual DbSet<Room>                  Rooms                   { get; set; } = null!;
    public virtual DbSet<RoomAllocation>        RoomAllocations         { get; set; } = null!;
    public virtual DbSet<RoomAssignment>        RoomAssignments         { get; set; } = null!;
    public virtual DbSet<Drug>                  Drugs                   { get; set; } = null!;
    public virtual DbSet<DrugInventory>         DrugInventorys          { get; set; } = null!;
    public virtual DbSet<Storage>               Storages                { get; set; } = null!;
    public virtual DbSet<GoodSuppling>          GoodSupplings           { get; set; } = null!;
    public virtual DbSet<Importation>           Importations            { get; set; } = null!;
    public virtual DbSet<DeviceInventory>       DeviceInventorys        { get; set; } = null!;
    public virtual DbSet<Diagnosis>             Diagnosises             { get; set; } = null!;
    public virtual DbSet<DiagnosisSuggestion>   DiagnosisSuggestions    { get; set; } = null!;
    public virtual DbSet<ICD>                   ICDs                    { get; set; } = null!;
    public virtual DbSet<ICDD>                  ICDDs                   { get; set; } = null!;
    public virtual DbSet<MedicalExam>           MedicalExams            { get; set; } = null!;
    public virtual DbSet<MedicalExamEposode>    MedicalExamEposodes     { get; set; } = null!;
    public virtual DbSet<Treatment>             Treatments              { get; set; } = null!;
    public virtual DbSet<DeviceService>         DeviceServices          { get; set; } = null!;
    public virtual DbSet<MedicalDevice>         MedicalDevices          { get; set; } = null!;
    public virtual DbSet<Service>               Services                { get; set; } = null!;
    public virtual DbSet<AnalysisTest>          AnalysisTests           { get; set; } = null!;
    public virtual DbSet<Bill>                  Bills                   { get; set; } = null!;
    public virtual DbSet<DrugBillDetail>        DrugBillDetails         { get; set; } = null!;
    public virtual DbSet<Transaction>           Transactions            { get; set; } = null!;
}
