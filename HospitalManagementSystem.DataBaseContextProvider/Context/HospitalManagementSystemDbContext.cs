namespace HospitalManagementSystem.DataBaseContextProvider;

public class HospitalManagementSystemDbContext : DbContext
{
    public HospitalManagementSystemDbContext(DbContextOptions<HospitalManagementSystemDbContext> options) : base(options) { }

    public virtual DbSet<AnalyzationTest>               AnalyzationTests        { get; set; } = null!;
    public virtual DbSet<DeviceService>                 DeviceServices          { get; set; } = null!;
    public virtual DbSet<Doctor>                        Doctors                 { get; set; } = null!;
    public virtual DbSet<Employee>                      Employees               { get; set; } = null!;
    public virtual DbSet<Drug>                          Drugs                   { get; set; } = null!;
    public virtual DbSet<PatientTransactionHistory>     TransactionHistorys     { get; set; } = null!;
    public virtual DbSet<GoodsImportation>              GetGoodsImportations    { get; set; } = null!;
    public virtual DbSet<HistoryMedicalExam>            HistoryMedicalExams     { get; set; } = null!;
    public virtual DbSet<Inventory>                     Inventories             { get; set; } = null!;
    public virtual DbSet<Patient>                       Patients                { get; set; } = null!;
    public virtual DbSet<Suppling>                      Supplings               { get; set; } = null!;
    public virtual DbSet<Storage>                       Storages                { get; set; } = null!;
    public virtual DbSet<Bill>                          Bills                   { get; set; } = null!;
    public virtual DbSet<User>                          Users                   { get; set; } = null!;
    public virtual DbSet<Role>                          Roles                   { get; set; } = null!;


    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }
}
