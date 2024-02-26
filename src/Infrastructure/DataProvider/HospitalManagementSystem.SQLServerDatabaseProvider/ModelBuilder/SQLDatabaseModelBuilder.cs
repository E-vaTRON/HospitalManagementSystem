using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HospitalManagementSystem.DataProvider;

public class SQLDatabaseModelBuilder
{
    //using singleton for sqldatabase
    #region [ Singleton ]
    private static readonly Lazy<SQLDatabaseModelBuilder> current = new Lazy<SQLDatabaseModelBuilder>(
        () => new SQLDatabaseModelBuilder(), LazyThreadSafetyMode.PublicationOnly);
    public static SQLDatabaseModelBuilder Current
    {
        get => current.Value; 
    }
    #endregion

    #region [ CTor ]
    public SQLDatabaseModelBuilder() { }
    #endregion

    #region [ Public Method ]
    public Microsoft.EntityFrameworkCore.Metadata.IModel GetModel()
    {
        var builder = new ModelBuilder();

        this.CreateModels(builder);

        return builder.FinalizeModel();
    }
    #endregion

    #region [ Private Method ]
    private void CreateModels(ModelBuilder modelBuilder)
    {
        //this.CreateModel_Playlist(modelBuilder);

    }
    #endregion

    #region [ Model Builder Base ]
    private void BaseModelBuilder<TModel>(ModelBuilder modelBuilder, string modelName)
        where TModel : ModelBase
    {
        //Init Primary Key
        modelBuilder.Entity<TModel>().HasKey(x => x.Id);

        modelBuilder.Entity<TModel>()
                    .Property(x => x.Id)
                    .HasColumnType("nvarchar")
                    .HasMaxLength(DataTypeHelpers.ID_FIELD_LENGTH)
                    .IsRequired(true);

        modelBuilder.Entity<TModel>()
                    .Property(x => x.CreatedOn)
                    .HasColumnType("datetime")
                    .IsRequired(true);

        modelBuilder.Entity<TModel>()
                    .Property(x => x.LastUpdatedOn)
                    .HasColumnType("datetime")
                    .IsRequired(true);


        modelBuilder.Entity<TModel>()
                    .Property(x => x.DeleteOn)
                    .HasColumnType("datetime")
                    .IsRequired(true);

        modelBuilder.Entity<TModel>()
                    .Property(x => x.IsDeleted)
                    .HasColumnType("bit")
                    .IsRequired(true);
    }
    #endregion

    #region [ Model Builder ]
    private void RoomModelBuilder(ModelBuilder modelBuilder)
    {
        this.BaseModelBuilder<Room>(modelBuilder, nameof(Room));

        modelBuilder.Entity<Room>()
                    .Property(x => x.Name)
                    .HasColumnType("nvarchar")
                    .HasMaxLength(DataTypeHelpers.NAME_FIELD_LENGTH)
                    .IsRequired(true);

        modelBuilder.Entity<Room>()
                    .Property(x => x.RoomType)
                    .HasColumnType("nvarchar")
                    .HasConversion(new EnumToStringConverter<RoomType>())
                    .HasMaxLength(DataTypeHelpers.TITLE_FIELD_LENGTH)
                    .IsRequired(true);

        modelBuilder.Entity<Room>()
                    .Property(x => x.Capacity)
                    .HasColumnType("int")
                    .IsRequired(true);

        modelBuilder.Entity<Room>()
                    .Property(x => x.RoomType)
                    .HasColumnType("nvarchar")
                    .HasConversion(new EnumToStringConverter<RoomStatus>())
                    .HasMaxLength(DataTypeHelpers.TITLE_FIELD_LENGTH)
                    .IsRequired(true);

        modelBuilder.Entity<Room>()
                    .HasOne(r => r.Department)
                    .WithMany(d => d.Rooms)
                    .HasForeignKey(r => r.DepartmentId);
    }
    private void RoomAssignmentModelBuilder(ModelBuilder modelBuilder)
    {
        this.BaseModelBuilder<RoomAssignment>(modelBuilder, nameof(RoomAssignment));

        modelBuilder.Entity<RoomAssignment>()
                    .Property(x => x.StartTime)
                    .HasColumnType("datetime")
                    .HasMaxLength(DataTypeHelpers.NAME_FIELD_LENGTH)
                    .IsRequired(true);

        modelBuilder.Entity<RoomAssignment>()
                    .Property(x => x.EndTime)
                    .HasColumnType("datetime")
                    .HasMaxLength(DataTypeHelpers.TITLE_FIELD_LENGTH)
                    .IsRequired(true);

        modelBuilder.Entity<RoomAssignment>()
                    .HasOne(ra => ra.Employee)
                    .WithMany(e => e.RoomAssignments)
                    .HasForeignKey(ra => ra.EmployeeId);

        modelBuilder.Entity<RoomAssignment>()
                    .HasOne(ra => ra.Room)
                    .WithMany(r => r.RoomAssignments)
                    .HasForeignKey(ra => ra.RoomId);
    }
    private void RoomAllocationModelBuilder(ModelBuilder modelBuilder)
    {
        this.BaseModelBuilder<RoomAllocation>(modelBuilder, nameof(RoomAllocation));

        modelBuilder.Entity<RoomAllocation>()
                    .Property(x => x.StartTime)
                    .HasColumnType("datetime")
                    .HasMaxLength(DataTypeHelpers.NAME_FIELD_LENGTH)
                    .IsRequired(true);

        modelBuilder.Entity<RoomAllocation>()
                    .Property(x => x.EndTime)
                    .HasColumnType("datetime")
                    .HasMaxLength(DataTypeHelpers.TITLE_FIELD_LENGTH)
                    .IsRequired(true);

        modelBuilder.Entity<RoomAllocation>()
                    .HasOne(ra => ra.Patient)
                    .WithMany(p => p.RoomAllocations)
                    .HasForeignKey(ra => ra.PatientId);

        modelBuilder.Entity<RoomAllocation>()
                    .HasOne(ra => ra.Room)
                    .WithMany(r => r.RoomAllocations)
                    .HasForeignKey(ra => ra.RoomId);

        modelBuilder.Entity<RoomAllocation>()
                    .HasOne(ra => ra.MedicalExamEposode)
                    .WithMany(me => me.RoomAllocations)
                    .HasForeignKey(ra => ra.MedicalExamEposodeId);
    }
    private void DepartmentModelBuilder(ModelBuilder modelBuilder)
    {
        this.BaseModelBuilder<Department>(modelBuilder, nameof(Department));

        modelBuilder.Entity<Room>()
                    .Property(x => x.Name)
                    .HasColumnType("nvarchar")
                    .HasMaxLength(DataTypeHelpers.NAME_FIELD_LENGTH)
                    .IsRequired(true);
    }
    private void DeviceInventoryModelBuilder(ModelBuilder modelBuilder)
    {
        this.BaseModelBuilder<DeviceInventory>(modelBuilder, nameof(DeviceInventory));

        modelBuilder.Entity<DeviceInventory>()
                    .Property(di => di.CurrentAmount)
                    .HasColumnType("int")
                    .IsRequired(true);

        modelBuilder.Entity<DeviceInventory>()
                    .HasOne(di => di.MedicalDevice)
                    .WithMany(md => md.DeviceInventorys)
                    .HasForeignKey(di => di.MedicalDeviceId);

        modelBuilder.Entity<DeviceInventory>()
                    .HasOne(di => di.Storage)
                    .WithMany(s => s.DeviceInventories)
                    .HasForeignKey(di => di.StorageId);
    }
    private void DrugModelBuilder(ModelBuilder modelBuilder)
    {
        this.BaseModelBuilder<Drug>(modelBuilder, nameof(Drug));

        modelBuilder.Entity<Drug>()
                    .Property(d => d.GoodName)
                    .HasColumnType("nvarchar")
                    .HasMaxLength(DataTypeHelpers.NAME_FIELD_LENGTH)
                    .IsRequired();

        modelBuilder.Entity<Drug>()
                    .Property(d => d.ActiveIngredientName)
                    .HasColumnType("nvarchar")
                    .HasMaxLength(DataTypeHelpers.NAME_FIELD_LENGTH)
                    .IsRequired();

        modelBuilder.Entity<Drug>()
                    .Property(d => d.Unit)
                    .HasColumnType("nvarchar")
                    .HasConversion(new EnumToStringConverter<Units>())
                    .HasMaxLength(DataTypeHelpers.NAME_FIELD_LENGTH)
                    .IsRequired();

        modelBuilder.Entity<Drug>()
                    .Property(d => d.GoodType)
                    .HasColumnType("nvarchar")
                    .HasMaxLength(DataTypeHelpers.NAME_FIELD_LENGTH)
                    .IsRequired();

        modelBuilder.Entity<Drug>()
                    .Property(d => d.UnitPrice)
                    .HasColumnType("nvarchar")
                    .HasMaxLength(DataTypeHelpers.NAME_FIELD_LENGTH)
                    .IsRequired();

        modelBuilder.Entity<Drug>()
                    .Property(d => d.HealthInsurancePrice)
                    .HasColumnType("nvarchar")
                    .HasMaxLength(DataTypeHelpers.NAME_FIELD_LENGTH)
                    .IsRequired();

        modelBuilder.Entity<Drug>()
                    .Property(d => d.Country)
                    .HasColumnType("nvarchar")
                    .HasMaxLength(DataTypeHelpers.NAME_FIELD_LENGTH)
                    .IsRequired();

        modelBuilder.Entity<Drug>()
                    .Property(d => d.GroupId)
                    .HasColumnType("nvarchar")
                    .HasMaxLength(DataTypeHelpers.NAME_FIELD_LENGTH)
                    .IsRequired();
    }
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
