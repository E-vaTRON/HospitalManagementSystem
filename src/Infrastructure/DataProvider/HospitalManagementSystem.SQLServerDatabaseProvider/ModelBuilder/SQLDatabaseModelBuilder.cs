namespace HospitalManagementSystem.SQLServerDatabaseProvider;

public class SQLDatabaseModelBuilder
{
    //using singleton for sqldatabase
    #region [ Singleton ]
    private static readonly Lazy<SQLDatabaseModelBuilder> _current = new Lazy<SQLDatabaseModelBuilder>(()
       => new SQLDatabaseModelBuilder(), LazyThreadSafetyMode.PublicationOnly);
    public static SQLDatabaseModelBuilder Current
    {
        get { return _current.Value; }
    }
    #endregion

    #region [ CTor ]
    public SQLDatabaseModelBuilder()
    {

    }
    #endregion

    #region [ Public Method ]
    public IModel GetModel()
    {
        var builder = new ModelBuilder();

        this.CreateModels(builder);

        return builder.FinalizeModel();
    }
    #endregion

    #region [ Private Methods ]
    private void CreateModels(ModelBuilder modelBuilder)
    {
        //this.CreateModel_Playlist(modelBuilder);

    }
    #endregion

    #region [ Private Method - Base ]
    //private void CreateModel_Base<TEntity>(ModelBuilder modelBuilder, string modelName)
    //   where TEntity : BaseModel<Guid>
    //{
    //    //Init Primary Key
    //    modelBuilder.Entity<TEntity>().HasKey(x => x.Id);

    //    modelBuilder.Entity<TEntity>()
    //                .Property(x => x.Id)
    //                .HasColumnType("nvarchar")
    //                .HasMaxLength(DataTypeHelpers.ID_FIELD_LENGTH)
    //                .IsRequired(true);

    //    modelBuilder.Entity<TEntity>()
    //                .Property(x => x.CreatedOn)
    //                .HasColumnType("datetime")
    //                .IsRequired(true);

    //    modelBuilder.Entity<TEntity>()
    //                .Property(x => x.LastUpdatedOn)
    //                .HasColumnType("datetime")
    //                .IsRequired(true);
    //}
    #endregion

    //    builder.Entity<User>(entity =>
    //        {
    //            entity.Property(e => e.Guid).HasDefaultValueSql("NEWID()");
    //    entity.HasIndex(e => e.Guid).IsUnique();
    //});

    //        builder.Entity<UserRole>(entity =>
    //        {
    //            entity.HasOne(ur => ur.Role)
    //                  .WithMany(r => r!.UserRoles)
    //                  .HasForeignKey(ur => ur.ID)
    //                  .IsRequired().OnDelete(DeleteBehavior.Cascade);

    //entity.HasOne(ur => ur.User)
    //                  .WithMany(u => u!.UserRoles)
    //                  .HasForeignKey(ur => ur.ID)
    //                  .IsRequired().OnDelete(DeleteBehavior.Cascade);
    //        });

    //builder.Entity<Inventory>(entity =>
    //{

    //    entity.HasOne(i => i.Storage)
    //          .WithMany(d => d!.Inventories)
    //          .HasForeignKey(i => i!.StorageID)
    //          .OnDelete(DeleteBehavior.Cascade);
    //});

    //builder.Entity<PatientTransactionHistory>(entity =>
    //{
    //    entity.HasOne(p => p.Exam)
    //          .WithOne(e => e.Transaction)
    //          .HasForeignKey<HistoryMedicalExam>(e => e.TransactionID)
    //          .OnDelete(DeleteBehavior.Cascade);
    //});

    //builder.Entity<HistoryMedicalExam>(entity =>
    //{
    //    entity.HasOne(h => h.Patient)
    //          .WithMany(p => p!.Exams)
    //          .HasForeignKey(h => h.PatientID)
    //          .OnDelete(DeleteBehavior.Restrict);

    //    entity.HasOne(h => h.Doctor)
    //          .WithMany(d => d!.Exams)
    //          .HasForeignKey(h => h.DoctorID)
    //          .IsRequired()
    //          .OnDelete(DeleteBehavior.Restrict);

    //    entity.HasOne(h => h.Employee)
    //          .WithMany(e => e!.Exams)
    //          .HasForeignKey(h => h.EmployeeID)
    //          .IsRequired()
    //          .OnDelete(DeleteBehavior.Restrict);

    //    entity.HasOne(e => e.Transaction)
    //          .WithOne(p => p.Exam)
    //          .HasForeignKey<PatientTransactionHistory>(p => p.ExamID)
    //          .OnDelete(DeleteBehavior.Cascade);
    //});

    //builder.Entity<
    //
    //Test>(entity =>
    //{
    //    entity.HasOne(a => a.HistoryMedicalExam)
    //          .WithMany(p => p!.AnalyzationTests)
    //          .HasForeignKey(a => a.ExamID)
    //          .OnDelete(DeleteBehavior.Cascade);

    //    entity.HasOne(a => a.DeviceService)
    //          .WithMany(d => d!.AnalyzationTests)
    //          .HasForeignKey(a => a.DeviceID)
    //          .OnDelete(DeleteBehavior.Cascade);
    //});

    //builder.Entity<Suppling>(entity =>
    //{
    //    entity.HasOne(s => s.Inventory)
    //          .WithMany(i => i!.Supplings)
    //          .HasForeignKey(s => s.InventoryID)
    //          .OnDelete(DeleteBehavior.Restrict);

    //    entity.HasOne(s => s.GoodsImportation)
    //          .WithMany(g => g!.Goods)
    //          .HasForeignKey(s => s.ShipmentID)
    //          .IsRequired()
    //          .OnDelete(DeleteBehavior.Cascade);

    //    entity.HasOne(s => s.Drug)
    //          .WithMany(d => d!.Supplings)
    //          .HasForeignKey(s => s.DrugID)
    //          .IsRequired()
    //          .OnDelete(DeleteBehavior.Cascade);
    //});

    //builder.Entity<Bill>(entity =>
    //{
    //    entity.HasOne(b => b.Inventory)
    //          .WithMany(i => i!.Bills)
    //          .HasForeignKey(b => b.InventoryID)
    //          .OnDelete(DeleteBehavior.Restrict);

    //    entity.HasOne(b => b.Transaction)
    //          .WithMany(g => g!.Bills)
    //          .HasForeignKey(b => b.TransactionID)
    //          .IsRequired()
    //          .OnDelete(DeleteBehavior.Cascade);

    //    entity.HasOne(b => b.Drug)
    //          .WithMany(d => d!.Bills)
    //          .HasForeignKey(b => b.DrugID)
    //          .IsRequired()
    //          .OnDelete(DeleteBehavior.Cascade);
    //});
}
