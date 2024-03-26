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

    #region [ Function ]
    private void AlertModelBuilder(ModelBuilder modelBuilder)
    {
        this.BaseModelBuilder<Alert>(modelBuilder, nameof(Alert));

        modelBuilder.Entity<Alert>()
                    .Property(x => x.Status)
                    .HasColumnType("nvarchar")
                    .HasMaxLength(DataTypeHelpers.TITLE_FIELD_LENGTH)
                    .IsRequired(true);

        modelBuilder.Entity<Alert>()
                    .Property(x => x.Message)
                    .HasColumnType("nvarchar")
                    .IsRequired(true);

        modelBuilder.Entity<Alert>()
                    .HasOne(a => a.User)
                    .WithMany(u => u.Alerts)
                    .HasForeignKey(a => a.UserId);
    }
    private void BookingAppointmentModelBuilder(ModelBuilder modelBuilder)
    {
        this.BaseModelBuilder<BookingAppointment>(modelBuilder, nameof(BookingAppointment));

        modelBuilder.Entity<BookingAppointment>()
                    .HasOne(ba => ba.Patient)
                    .WithMany(p => p.BookingAppointments)
                    .HasForeignKey(ba => ba.PatientId)
                    .IsRequired(true)
                    .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<BookingAppointment>()
                    .HasOne(ba => ba.Doctor)
                    .WithMany(d => d.BookingAppointments)
                    .HasForeignKey(ba => ba.DoctorId)
                    .IsRequired(true)
                    .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<BookingAppointment>()
                    .HasOne(ba => ba.MedicalExam)
                    .WithOne(me => me.BookingAppointment)
                    .HasForeignKey<BookingAppointment>(ba => ba.MedicalExamId)
                    .IsRequired(true)
                    .OnDelete(DeleteBehavior.Cascade);
    }
    private void ReExamAppointmentModelBuilder(ModelBuilder modelBuilder)
    {
        this.BaseModelBuilder<ReExamAppointment>(modelBuilder, nameof(ReExamAppointment));

        modelBuilder.Entity<ReExamAppointment>()
                    .HasOne(ra => ra.MedicalExamEposode)
                    .WithOne(mee => mee.ReExamAppointment)
                    .HasForeignKey<ReExamAppointment>(ra => ra.MedicalExamEposodeId)
                    .IsRequired(true)
                    .OnDelete(DeleteBehavior.Cascade);
    }
    private void ScheduleDayModelBuilder(ModelBuilder modelBuilder)
    {
        this.BaseModelBuilder<ScheduleDay>(modelBuilder, nameof(ScheduleDay));

        modelBuilder.Entity<ScheduleDay>()
                    .Property(x => x.WorkingDay)
                    .HasColumnType("nvarchar")
                    .HasConversion(new EnumToStringConverter<DayOfWeek>())
                    .HasMaxLength(DataTypeHelpers.TITLE_FIELD_LENGTH)
                    .IsRequired(true);

        modelBuilder.Entity<ScheduleDay>()
                    .Property(x => x.IsFlexible)
                    .HasColumnType("bit")
                    .IsRequired(true);

        modelBuilder.Entity<ScheduleDay>()
                    .HasOne(sd => sd.Employee)
                    .WithMany(e => e.EmployeeSchedules)
                    .HasForeignKey(sd => sd.EmployeeId)
                    .IsRequired(true)
                    .OnDelete(DeleteBehavior.Cascade);
    }
    private void ScheduleSlotModelBuilder(ModelBuilder modelBuilder)
    {
        this.BaseModelBuilder<ScheduleSlot>(modelBuilder, nameof(ScheduleSlot));

        modelBuilder.Entity<ScheduleSlot>()
                    .Property(x => x.StartTime)
                    .HasColumnType("time")
                    .IsRequired(true);

        modelBuilder.Entity<ScheduleSlot>()
                    .Property(x => x.EndTime)
                    .HasColumnType("time")
                    .IsRequired(true);

        modelBuilder.Entity<ScheduleSlot>()
                    .Property(x => x.Task)
                    .HasColumnType("nvarchar")
                    .HasMaxLength(DataTypeHelpers.DESCRIPTION_NAME_FIELD_LENGTH)
                    .IsRequired(true);

        modelBuilder.Entity<ScheduleSlot>()
                    .HasOne(sl => sl.ScheduleDay)
                    .WithMany(sd => sd.ScheduleSlots)
                    .HasForeignKey(sl => sl.ScheduleDayId)
                    .IsRequired(true)
                    .OnDelete(DeleteBehavior.Cascade);
    }
    private void ReferralModelBuilder(ModelBuilder modelBuilder)
    {
        this.BaseModelBuilder<Referral>(modelBuilder, nameof(Referral));

        modelBuilder.Entity<Referral>()
                    .Property(x => x.DateOfReferral)
                    .HasColumnType("datetime")
                    .IsRequired(true);

        modelBuilder.Entity<Referral>()
                    .Property(x => x.Reason)
                    .HasColumnType("int")
                    .HasMaxLength(DataTypeHelpers.DESCRIPTION_NAME_FIELD_LENGTH)
                    .IsRequired(true);

        modelBuilder.Entity<Referral>()
                    .Property(x => x.Urgency)
                    .HasColumnType("nvarchar")
                    .HasMaxLength(DataTypeHelpers.DESCRIPTION_NAME_FIELD_LENGTH)
                    .IsRequired(true);

        modelBuilder.Entity<Referral>()
                    .HasOne(r => r.MedicalExam)
                    .WithMany(d => d.Referrals)
                    .HasForeignKey(r => r.MedicalExamId)
                    .IsRequired(true)
                    .OnDelete(DeleteBehavior.Cascade);
    }
    private void ReferralDoctorModelBuilder(ModelBuilder modelBuilder)
    {
        this.BaseModelBuilder<ReferralDoctor>(modelBuilder, nameof(ReferralDoctor));

        modelBuilder.Entity<ReferralDoctor>()
                    .Property(x => x.ReferralStatus)
                    .HasColumnType("nvarchar")
                    .IsRequired(true);

        modelBuilder.Entity<ReferralDoctor>()
                    .HasOne(rd => rd.ReferringDoctor)
                    .WithMany(d => d.ReferralDoctors)
                    .HasForeignKey(rd => rd.ReferringDoctorId)
                    .IsRequired(true)
                    .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<ReferralDoctor>()
                    .HasOne(rd => rd.ReferredDoctor)
                    .WithMany(d => d.ReferralDoctors)
                    .HasForeignKey(rd => rd.ReferredDoctorId)
                    .IsRequired(true)
                    .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<ReferralDoctor>()
                    .HasOne(ah => ah.AssignmentHistory)
                    .WithOne(rd => rd.ReferralDoctor)
                    .HasForeignKey<ReferralDoctor>(ah => ah.AssignmentHistoryId)
                    .IsRequired(false)
                    .OnDelete(DeleteBehavior.Cascade);
    }
    #endregion

    #region [ Infrastructure ]
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
                    .HasForeignKey(r => r.DepartmentId)
                    .IsRequired(true)
                    .OnDelete(DeleteBehavior.Cascade);
    }
    private void RoomAssignmentModelBuilder(ModelBuilder modelBuilder)
    {
        this.BaseModelBuilder<RoomAssignment>(modelBuilder, nameof(RoomAssignment));

        modelBuilder.Entity<RoomAssignment>()
                    .Property(x => x.StartTime)
                    .HasColumnType("datetime")
                    .IsRequired(true);

        modelBuilder.Entity<RoomAssignment>()
                    .Property(x => x.EndTime)
                    .HasColumnType("datetime")
                    .IsRequired(true);

        modelBuilder.Entity<RoomAssignment>()
                    .HasOne(ra => ra.Employee)
                    .WithMany(e => e.RoomAssignments)
                    .HasForeignKey(ra => ra.EmployeeId)
                    .IsRequired(true)
                    .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<RoomAssignment>()
                    .HasOne(ra => ra.Room)
                    .WithMany(r => r.RoomAssignments)
                    .HasForeignKey(ra => ra.RoomId)
                    .IsRequired(true)
                    .OnDelete(DeleteBehavior.Cascade);
    }
    private void RoomAllocationModelBuilder(ModelBuilder modelBuilder)
    {
        this.BaseModelBuilder<RoomAllocation>(modelBuilder, nameof(RoomAllocation));

        modelBuilder.Entity<RoomAllocation>()
                    .Property(x => x.StartTime)
                    .HasColumnType("datetime")
                    .IsRequired(true);

        modelBuilder.Entity<RoomAllocation>()
                    .Property(x => x.EndTime)
                    .HasColumnType("datetime")
                    .IsRequired(true);

        modelBuilder.Entity<RoomAllocation>()
                    .HasOne(ra => ra.Patient)
                    .WithMany(p => p.RoomAllocations)
                    .HasForeignKey(ra => ra.PatientId)
                    .IsRequired(true)
                    .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<RoomAllocation>()
                    .HasOne(ra => ra.Room)
                    .WithMany(r => r.RoomAllocations)
                    .HasForeignKey(ra => ra.RoomId)
                    .IsRequired(true)
                    .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<RoomAllocation>()
                    .HasOne(ra => ra.MedicalExamEposode)
                    .WithMany(mee => mee.RoomAllocations)
                    .HasForeignKey(ra => ra.MedicalExamEposodeId)
                    .IsRequired(true)
                    .OnDelete(DeleteBehavior.Cascade);
    }
    private void DepartmentModelBuilder(ModelBuilder modelBuilder)
    {
        this.BaseModelBuilder<Department>(modelBuilder, nameof(Department));

        modelBuilder.Entity<Department>()
                    .Property(x => x.Name)
                    .HasColumnType("nvarchar")
                    .HasMaxLength(DataTypeHelpers.NAME_FIELD_LENGTH)
                    .IsRequired(true);
    }
    #endregion

    #region [ Inventory ]
    private void DeviceInventoryModelBuilder(ModelBuilder modelBuilder)
    {
        this.BaseModelBuilder<DeviceInventory>(modelBuilder, nameof(DeviceInventory));

        modelBuilder.Entity<DeviceInventory>()
                    .Property(x => x.CurrentAmount)
                    .HasColumnType("int")
                    .IsRequired(true);

        modelBuilder.Entity<DeviceInventory>()
                    .HasOne(di => di.MedicalDevice)
                    .WithMany(md => md.DeviceInventorys)
                    .HasForeignKey(di => di.MedicalDeviceId)
                    .IsRequired(true)
                    .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<DeviceInventory>()
                    .HasOne(di => di.Storage)
                    .WithMany(s => s.DeviceInventories)
                    .HasForeignKey(di => di.StorageId)
                    .IsRequired(true)
                    .OnDelete(DeleteBehavior.Cascade);
    }
    private void DrugModelBuilder(ModelBuilder modelBuilder)
    {
        this.BaseModelBuilder<Drug>(modelBuilder, nameof(Drug));

        modelBuilder.Entity<Drug>()
                    .Property(x => x.GoodName)
                    .HasColumnType("nvarchar")
                    .HasMaxLength(DataTypeHelpers.NAME_FIELD_LENGTH)
                    .IsRequired(true);

        modelBuilder.Entity<Drug>()
                    .Property(x => x.ActiveIngredientName)
                    .HasColumnType("nvarchar")
                    .HasMaxLength(DataTypeHelpers.NAME_FIELD_LENGTH)
                    .IsRequired(true);

        modelBuilder.Entity<Drug>()
                    .Property(x => x.Unit)
                    .HasColumnType("nvarchar")
                    .HasConversion(new EnumToStringConverter<Units>())
                    .HasMaxLength(DataTypeHelpers.NAME_FIELD_LENGTH)
                    .IsRequired(true);

        modelBuilder.Entity<Drug>()
                    .Property(x => x.GoodType)
                    .HasColumnType("nvarchar")
                    .HasMaxLength(DataTypeHelpers.NAME_FIELD_LENGTH)
                    .IsRequired(true);

        modelBuilder.Entity<Drug>()
                    .Property(x => x.UnitPrice)
                    .HasColumnType("nvarchar")
                    .HasMaxLength(DataTypeHelpers.NAME_FIELD_LENGTH)
                    .IsRequired(true);

        modelBuilder.Entity<Drug>()
                    .Property(x => x.HealthInsurancePrice)
                    .HasColumnType("nvarchar")
                    .HasMaxLength(DataTypeHelpers.NAME_FIELD_LENGTH)
                    .IsRequired(true);

        modelBuilder.Entity<Drug>()
                    .Property(x => x.Country)
                    .HasColumnType("nvarchar")
                    .HasMaxLength(DataTypeHelpers.NAME_FIELD_LENGTH)
                    .IsRequired(true);

        modelBuilder.Entity<Drug>()
                    .Property(x => x.GroupId)
                    .HasColumnType("nvarchar")
                    .HasMaxLength(DataTypeHelpers.ID_FIELD_LENGTH)
                    .IsRequired(true);
    }
    private void DrugInventoryModelBuilder(ModelBuilder modelBuilder)
    {
        this.BaseModelBuilder<DrugInventory>(modelBuilder, nameof(DrugInventory));

        modelBuilder.Entity<DrugInventory>()
                    .Property(x => x.CurrentAmount)
                    .HasColumnType("int")
                    .IsRequired();

        modelBuilder.Entity<DrugInventory>()
                    .HasOne(di => di.Storage)
                    .WithMany(s => s.DrugInventories)
                    .HasForeignKey(di => di.StorageId)
                    .IsRequired(true)
                    .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<DrugInventory>()
                    .HasOne(di => di.GoodSuppling)
                    .WithOne(gs => gs.Inventory)
                    .HasForeignKey<DrugInventory>(di => di.GoodSupplingId)
                    .IsRequired(true)
                    .OnDelete(DeleteBehavior.Cascade);
    }
    private void GoodSupplingModelBuilder(ModelBuilder modelBuilder)
    {
        this.BaseModelBuilder<GoodSuppling>(modelBuilder, nameof(GoodSuppling));

        modelBuilder.Entity<GoodSuppling>()
                    .Property(x => x.GoodInformation)
                    .HasColumnType("nvarchar")
                    .HasMaxLength(DataTypeHelpers.DESCRIPTION_NAME_FIELD_LENGTH)
                    .IsRequired(false);

        modelBuilder.Entity<GoodSuppling>()
                    .Property(x => x.ExpiryDate)
                    .HasColumnType("datetime")
                    .IsRequired(true);

        modelBuilder.Entity<GoodSuppling>()
                    .Property(x => x.OrinaryAmount)
                    .HasColumnType("int")
                    .IsRequired(true);

        modelBuilder.Entity<GoodSuppling>()
                    .HasOne(gs => gs.Importation)
                    .WithMany(i => i.GoodSupplings)
                    .HasForeignKey(gs => gs.ImportationId)
                    .IsRequired(true)
                    .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<GoodSuppling>()
                    .HasOne(gs => gs.Inventory)
                    .WithOne(i => i.GoodSuppling)
                    .HasForeignKey<GoodSuppling>(gs => gs.InventoryId)
                    .IsRequired(true)
                    .OnDelete(DeleteBehavior.Cascade);
        
        modelBuilder.Entity<GoodSuppling>()
                    .HasOne(gs => gs.Drug)
                    .WithMany(d => d.GoodSupplings)
                    .HasForeignKey(gs => gs.DrugId)
                    .IsRequired(true)
                    .OnDelete(DeleteBehavior.Cascade);
    }
    private void ImportationModelBuilder(ModelBuilder modelBuilder)
    {
        this.BaseModelBuilder<Importation>(modelBuilder, nameof(Importation));

        modelBuilder.Entity<Importation>()
                    .Property(x => x.ReceiptNumber)
                    .HasColumnType("nvarchar")
                    .HasMaxLength(DataTypeHelpers.DESCRIPTION_NAME_FIELD_LENGTH)
                    .IsRequired(true);

        modelBuilder.Entity<Importation>()
                    .Property(x => x.Billnumber)
                    .HasColumnType("nvarchar")
                    .HasMaxLength(DataTypeHelpers.DESCRIPTION_NAME_FIELD_LENGTH)
                    .IsRequired(true);

        modelBuilder.Entity<Importation>()
                    .Property(x => x.RecordDay)
                    .HasColumnType("datetime")
                    .IsRequired(true);

        modelBuilder.Entity<Importation>()
                    .Property(x => x.ReceiptDay)
                    .HasColumnType("datetime")
                    .IsRequired(true);

        modelBuilder.Entity<Importation>()
                    .Property(x => x.Tax)
                    .HasColumnType("int")
                    .IsRequired(true);

        modelBuilder.Entity<Importation>()
                    .Property(x => x.TotalPrice)
                    .HasColumnType("int")
                    .IsRequired(true);

        modelBuilder.Entity<Importation>()
                    .Property(x => x.Company)
                    .HasColumnType("nvarchar")
                    .HasMaxLength(DataTypeHelpers.DESCRIPTION_NAME_FIELD_LENGTH)
                    .IsRequired(true);

        modelBuilder.Entity<Importation>()
                    .HasMany(i => i.GoodSupplings)
                    .WithOne(gs => gs.Importation)
                    .HasForeignKey(i => i.ImportationId)
                    .IsRequired(true)
                    .OnDelete(DeleteBehavior.Cascade);
    }
    private void StorageModelBuilder(ModelBuilder modelBuilder)
    {
        this.BaseModelBuilder<Storage>(modelBuilder, nameof(Storage));

        modelBuilder.Entity<Storage>()
                    .Property(x => x.Location)
                    .HasColumnType("nvarchar")
                    .HasMaxLength(DataTypeHelpers.ADDRESS_FIELD_LENGTH)
                    .IsRequired(true);

        modelBuilder.Entity<Storage>()
                    .HasMany(s => s.DrugInventories)
                    .WithOne(di => di.Storage)
                    .HasForeignKey(s => s.StorageId)
                    .IsRequired(true)
                    .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Storage>()
                    .HasMany(s => s.DeviceInventories)
                    .WithOne(di => di.Storage)
                    .HasForeignKey(s => s.StorageId)
                    .IsRequired(true)
                    .OnDelete(DeleteBehavior.Cascade);
    }
    #endregion

    #region [ Medical ]
    private void AssignmentHistoryModelBuilder(ModelBuilder modelBuilder)
    {
        this.BaseModelBuilder<AssignmentHistory>(modelBuilder, nameof(AssignmentHistory));

        modelBuilder.Entity<AssignmentHistory>()
                    .Property(x => x.AssignmentStatus)
                    .HasColumnType("nvarchar")
                    .IsRequired(true);

        modelBuilder.Entity<AssignmentHistory>()
                    .HasOne(rd => rd.MedicalExamEposode)
                    .WithMany(mee => mee.AssignmentHistories)
                    .HasForeignKey(rd => rd.MedicalExamEposodeId)
                    .IsRequired(true)
                    .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<AssignmentHistory>()
                    .HasOne(ah => ah.Doctor)
                    .WithMany(d => d.AssignmentHistories)
                    .HasForeignKey(ah => ah.Doctor)
                    .IsRequired(true)
                    .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<AssignmentHistory>()
                    .HasOne(ah => ah.ReferralDoctor)
                    .WithOne(rd => rd.AssignmentHistory)
                    .HasForeignKey<AssignmentHistory>(ah => ah.ReferralDoctorId)
                    .IsRequired(false)
                    .OnDelete(DeleteBehavior.Cascade);
    }
    private void DiagnosisModelBuilder(ModelBuilder modelBuilder)
    {
        this.BaseModelBuilder<Diagnosis>(modelBuilder, nameof(Diagnosis));

        modelBuilder.Entity<Diagnosis>()
                    .Property(x => x.DiagnosisCode)
                    .HasColumnType("nvarchar")
                    .HasMaxLength(DataTypeHelpers.ID_FIELD_LENGTH)
                    .IsRequired(true);

        modelBuilder.Entity<Diagnosis>()
                    .Property(x => x.Description)
                    .HasColumnType("nvarchar")
                    .HasMaxLength(DataTypeHelpers.DESCRIPTION_NAME_FIELD_LENGTH)
                    .IsRequired(true);

        modelBuilder.Entity<Diagnosis>()
                    .HasOne(d => d.MedicalExamEposode)
                    .WithMany(me => me.Diagnosis)
                    .HasForeignKey(d => d.ExamEposodeId)
                    .IsRequired(true)
                    .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Diagnosis>()
                    .HasOne(d => d.ICDD)
                    .WithMany(i => i.Diagnoses)
                    .HasForeignKey(d => d.ICDDId)
                    .IsRequired(true)
                    .OnDelete(DeleteBehavior.Cascade);
    }
    private void DiagnosisSuggestionModelBuilder(ModelBuilder modelBuilder)  // Bản này có thể không tạo
    {
        this.BaseModelBuilder<DiagnosisSuggestion>(modelBuilder, nameof(DiagnosisSuggestion));

        modelBuilder.Entity<DiagnosisSuggestion>()
                    .Property(x => x.ThresholdValue)
                    .HasColumnType("nvarchar")
                    .HasMaxLength(DataTypeHelpers.ID_FIELD_LENGTH)
                    .IsRequired(true);

        modelBuilder.Entity<DiagnosisSuggestion>()
                    .Property(x => x.IsActive)
                    .HasColumnType("bit")
                    .IsRequired(true);

        modelBuilder.Entity<DiagnosisSuggestion>()
                    .HasOne(ds => ds.AnalysisTest)
                    .WithMany(a => a.DiagnosisSuggestions)
                    .HasForeignKey(ds => ds.AnalysisTestId);

        modelBuilder.Entity<DiagnosisSuggestion>()
                    .HasOne(ds => ds.Diagnosis)
                    .WithMany(d => d.DiagnosisSuggestions)
                    .HasForeignKey(ds => ds.DiagnosisId);
    }
    private void ICDModelBuilder(ModelBuilder modelBuilder)
    {
        this.BaseModelBuilder<ICD>(modelBuilder, nameof(ICD));

        modelBuilder.Entity<ICD>()
                    .Property(x => x.Code)
                    .HasColumnType("nvarchar")
                    .HasMaxLength(DataTypeHelpers.ID_FIELD_LENGTH)
                    .IsRequired(true);

        modelBuilder.Entity<ICD>()
                    .Property(x => x.Description)
                    .HasColumnType("nvarchar")
                    .HasMaxLength(DataTypeHelpers.DESCRIPTION_NAME_FIELD_LENGTH)
                    .IsRequired(true);

        modelBuilder.Entity<ICD>()
                    .Property(x => x.Status)
                    .HasColumnType("nvarchar")
                    .HasConversion(new EnumToStringConverter<CodeStatus>())
                    .HasMaxLength(DataTypeHelpers.NAME_FIELD_LENGTH)
                    .IsRequired(true);
    }
    private void ICDDModelBuilder(ModelBuilder modelBuilder)
    {
        this.BaseModelBuilder<ICDD>(modelBuilder, nameof(ICDD));

        modelBuilder.Entity<ICDD>()
                    .Property(x => x.Code)
                    .HasColumnType("nvarchar")
                    .HasMaxLength(DataTypeHelpers.ID_FIELD_LENGTH)
                    .IsRequired(true);

        modelBuilder.Entity<ICDD>()
                    .Property(x => x.Description)
                    .HasColumnType("nvarchar")
                    .HasMaxLength(DataTypeHelpers.DESCRIPTION_NAME_FIELD_LENGTH)
                    .IsRequired(true);

        modelBuilder.Entity<ICDD>()
                    .Property(x => x.Status)
                    .HasColumnType("nvarchar")
                    .HasConversion(new EnumToStringConverter<CodeStatus>())
                    .HasMaxLength(DataTypeHelpers.NAME_FIELD_LENGTH)
                    .IsRequired(true);
    }
    private void MedicalExamModelBuilder(ModelBuilder modelBuilder)
    {
        this.BaseModelBuilder<MedicalExam>(modelBuilder, nameof(MedicalExam));

        modelBuilder.Entity<MedicalExam>()
                    .HasOne(me => me.BookingAppointment)
                    .WithOne(ba => ba.MedicalExam)
                    .HasForeignKey<MedicalExam>(me => me.BookingAppointmentId)
                    .IsRequired(true)
                    .OnDelete(DeleteBehavior.Cascade);
    }
    private void MedicalExamEposodeModelBuilder(ModelBuilder modelBuilder)
    {
        this.BaseModelBuilder<MedicalExamEposode>(modelBuilder, nameof(MedicalExamEposode));

        modelBuilder.Entity<MedicalExamEposode>()
                    .Property(x => x.DateTakeExam)
                    .HasColumnType("datetime")
                    .IsRequired(true);

        modelBuilder.Entity<MedicalExamEposode>()
                    .Property(x => x.DateReExam)
                    .HasColumnType("datetime")
                    .IsRequired(true);

        modelBuilder.Entity<MedicalExamEposode>()
                    .Property(x => x.LineNumber)
                    .HasColumnType("int")
                    .IsRequired(true);

        modelBuilder.Entity<MedicalExamEposode>()
                    .HasOne(mee => mee.ReExamAppointment)
                    .WithOne(rea => rea.MedicalExamEposode)
                    .HasForeignKey<MedicalExamEposode>(mee => mee.ReExamAppointmentId)
                    .IsRequired(true)
                    .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<MedicalExamEposode>()
                    .HasOne(mee => mee.MedicalExam)
                    .WithMany(me => me.MedicalExamEposodes)
                    .HasForeignKey(mee => mee.MedicalExamId)
                    .IsRequired(true)
                    .OnDelete(DeleteBehavior.Cascade);
    }
    private void TreatmentModelBuilder(ModelBuilder modelBuilder)
    {
        this.BaseModelBuilder<Treatment>(modelBuilder, nameof(Treatment));

        modelBuilder.Entity<Treatment>()
                    .Property(x => x.TreatmentCode)
                    .HasColumnType("nvarchar")
                    .HasMaxLength(DataTypeHelpers.ID_FIELD_LENGTH)
                    .IsRequired(true);

        modelBuilder.Entity<Treatment>()
                    .Property(x => x.Description)
                    .HasColumnType("nvarchar")
                    .HasMaxLength(DataTypeHelpers.DESCRIPTION_NAME_FIELD_LENGTH)
                    .IsRequired(true);

        modelBuilder.Entity<Treatment>()
                    .HasOne(t => t.MedicalExamEposode)
                    .WithMany(me => me.Treatments)
                    .HasForeignKey(t => t.ExamEposodeId)
                    .IsRequired(true)
                    .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Treatment>()
                    .HasOne(t => t.ICD)
                    .WithMany(i => i.Treatments)
                    .HasForeignKey(t => t.ICDId)
                    .IsRequired(true)
                    .OnDelete(DeleteBehavior.Cascade);
    }
    #endregion

    #region [ Medical Device ]
    private void DeviceServiceModelBuilder(ModelBuilder modelBuilder)
    {
        this.BaseModelBuilder<DeviceService>(modelBuilder, nameof(DeviceService));

        modelBuilder.Entity<DeviceService>()
                    .HasOne(ds => ds.DeviceInventory)
                    .WithMany(di => di.DeviceServices)
                    .HasForeignKey(ds => ds.DeviceInventoryId)
                    .IsRequired(true)
                    .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<DeviceService>()
                    .HasOne(ds => ds.Service)
                    .WithMany(s => s.DeviceServices)
                    .HasForeignKey(ds => ds.ServiceId)
                    .IsRequired(true)
                    .OnDelete(DeleteBehavior.Cascade);
    }
    private void MedicalDeviceModelBuilder(ModelBuilder modelBuilder)
    {
        this.BaseModelBuilder<MedicalDevice>(modelBuilder, nameof(MedicalDevice));

        modelBuilder.Entity<MedicalDevice>()
                    .Property(x => x.Name)
                    .HasColumnType("nvarchar")
                    .HasMaxLength(DataTypeHelpers.NAME_FIELD_LENGTH)
                    .IsRequired(true);

        modelBuilder.Entity<MedicalDevice>()
                    .Property(x => x.Country)
                    .HasColumnType("nvarchar")
                    .HasMaxLength(DataTypeHelpers.NAME_FIELD_LENGTH)
                    .IsRequired(true);

        modelBuilder.Entity<MedicalDevice>()
                    .Property(x => x.SmallID)
                    .HasColumnType("nvarchar")
                    .HasMaxLength(DataTypeHelpers.ID_FIELD_LENGTH)
                    .IsRequired(true);

        modelBuilder.Entity<MedicalDevice>()
                    .Property(x => x.GroupID)
                    .HasColumnType("nvarchar")
                    .HasMaxLength(DataTypeHelpers.ID_FIELD_LENGTH)
                    .IsRequired(true);

        modelBuilder.Entity<MedicalDevice>()
                    .Property(x => x.Min)
                    .HasColumnType("int")
                    .IsRequired(true);

        modelBuilder.Entity<MedicalDevice>()
                    .Property(x => x.Max)
                    .HasColumnType("int")
                    .IsRequired(true);
    }
    private void ServiceModelBuilder(ModelBuilder modelBuilder)
    {
        this.BaseModelBuilder<Service>(modelBuilder, nameof(Service));

        modelBuilder.Entity<Service>()
                    .Property(x => x.Name)
                    .HasColumnType("nvarchar")
                    .HasMaxLength(DataTypeHelpers.NAME_FIELD_LENGTH)
                    .IsRequired(true);

        modelBuilder.Entity<Service>()
                    .Property(x => x.Unit)
                    .HasColumnType("nvarchar")
                    .HasConversion(new EnumToStringConverter<Units>())
                    .HasMaxLength(DataTypeHelpers.NAME_FIELD_LENGTH)
                    .IsRequired(true);

        modelBuilder.Entity<Service>()
                    .Property(x => x.UnitPrice)
                    .HasColumnType("int")
                    .IsRequired(true);

        modelBuilder.Entity<Service>()
                    .Property(x => x.ServicePrice)
                    .HasColumnType("int")
                    .IsRequired(true);

        modelBuilder.Entity<Service>()
                    .Property(x => x.HealthInsurancePrice)
                    .HasColumnType("int")
                    .IsRequired(true);

        modelBuilder.Entity<Service>()
                    .Property(x => x.ResultFromType)
                    .HasColumnType("nvarchar")
                    .HasConversion(new EnumToStringConverter<FormTypes>())
                    .HasMaxLength(DataTypeHelpers.NAME_FIELD_LENGTH)
                    .IsRequired(true);
    }
    private void AnalysisTestModelBuilder(ModelBuilder modelBuilder)
    {
        this.BaseModelBuilder<AnalysisTest>(modelBuilder, nameof(AnalysisTest));

        modelBuilder.Entity<AnalysisTest>()
                    .Property(x => x.DSymptom)
                    .HasColumnType("nvarchar")
                    .HasMaxLength(DataTypeHelpers.NAME_FIELD_LENGTH)
                    .IsRequired(true);

        modelBuilder.Entity<AnalysisTest>()
                    .Property(x => x.DoctorComment)
                    .HasColumnType("nvarchar")
                    .HasMaxLength(DataTypeHelpers.DESCRIPTION_NAME_FIELD_LENGTH)
                    .IsRequired(true);

        modelBuilder.Entity<AnalysisTest>()
                    .Property(x => x.Result)
                    .HasColumnType("nvarchar")
                    .HasMaxLength(DataTypeHelpers.DESCRIPTION_NAME_FIELD_LENGTH)
                    .IsRequired(true);

        modelBuilder.Entity<AnalysisTest>()
                    .HasOne(at => at.DeviceService)
                    .WithMany(ds => ds.AnalysisTests)
                    .HasForeignKey(at => at.DeviceServiceId)
                    .IsRequired(true)
                    .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<AnalysisTest>()
                    .HasOne(at => at.Bill)
                    .WithMany(b => b.AnalysisTests)
                    .HasForeignKey(at => at.BillId)
                    .IsRequired(true)
                    .OnDelete(DeleteBehavior.Cascade);
    }
    #endregion

    #region [ Transaction ]
    private void BillModelBuilder(ModelBuilder modelBuilder)
    {
        this.BaseModelBuilder<Bill>(modelBuilder, nameof(Bill));

        modelBuilder.Entity<Bill>()
                    .Property(x => x.TotalDrugPrice)
                    .HasColumnType("int")
                    .IsRequired(true);

        modelBuilder.Entity<Bill>()
                    .Property(x => x.TotalServicePrice)
                    .HasColumnType("int")
                    .IsRequired(true);

        modelBuilder.Entity<Bill>()
                    .HasOne(b => b.Transaction)
                    .WithMany(t => t.Bills)
                    .HasForeignKey(b => b.TransactionId)
                    .IsRequired(true)
                    .OnDelete(DeleteBehavior.Cascade);
    }
    private void DrugBillDetailModelBuilder(ModelBuilder modelBuilder)
    {
        this.BaseModelBuilder<DrugBillDetail>(modelBuilder, nameof(DrugBillDetail));

        modelBuilder.Entity<DrugBillDetail>()
                    .HasOne(dbd => dbd.Bill)
                    .WithMany(b => b.DrugBillDetails)
                    .HasForeignKey(dbd => dbd.BillId)
                    .IsRequired(true)
                    .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<DrugBillDetail>()
                    .HasOne(dbd => dbd.Inventory)
                    .WithMany(t => t.DrugBillDetails)
                    .HasForeignKey(dbd => dbd.InventoryId)
                    .IsRequired(true)
                    .OnDelete(DeleteBehavior.Cascade);
    }
    private void TransactionModelBuilder(ModelBuilder modelBuilder)
    {
        this.BaseModelBuilder<Transaction>(modelBuilder, nameof(Transaction));

        modelBuilder.Entity<Transaction>()
                    .Property(x => x.RecordDay)
                    .HasColumnType("datetime")
                    .IsRequired(true);

        modelBuilder.Entity<Transaction>()
                    .Property(x => x.TotalPrice)
                    .HasColumnType("int")
                    .IsRequired(true);

        modelBuilder.Entity<Transaction>()
                    .HasOne(t => t.MedicalExamEposode)
                    .WithMany(mee => mee.Transactions)
                    .HasForeignKey(t => t.MedicalExamEposodeId)
                    .IsRequired(true)
                    .OnDelete(DeleteBehavior.Cascade);
    }
    #endregion

    #endregion
}
