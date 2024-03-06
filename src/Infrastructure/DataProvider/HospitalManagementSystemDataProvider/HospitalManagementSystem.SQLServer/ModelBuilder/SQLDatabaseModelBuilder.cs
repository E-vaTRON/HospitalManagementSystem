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
                    .HasForeignKey(r => r.DepartmentId)
                    .IsRequired(true)
                    .OnDelete(DeleteBehavior.Cascade); ;
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
                    .WithMany(me => me.RoomAllocations)
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
                    .Property(d => d.GoodName)
                    .HasColumnType("nvarchar")
                    .HasMaxLength(DataTypeHelpers.NAME_FIELD_LENGTH)
                    .IsRequired(true);

        modelBuilder.Entity<Drug>()
                    .Property(d => d.ActiveIngredientName)
                    .HasColumnType("nvarchar")
                    .HasMaxLength(DataTypeHelpers.NAME_FIELD_LENGTH)
                    .IsRequired(true);

        modelBuilder.Entity<Drug>()
                    .Property(d => d.Unit)
                    .HasColumnType("nvarchar")
                    .HasConversion(new EnumToStringConverter<Units>())
                    .HasMaxLength(DataTypeHelpers.NAME_FIELD_LENGTH)
                    .IsRequired(true);

        modelBuilder.Entity<Drug>()
                    .Property(d => d.GoodType)
                    .HasColumnType("nvarchar")
                    .HasMaxLength(DataTypeHelpers.NAME_FIELD_LENGTH)
                    .IsRequired(true);

        modelBuilder.Entity<Drug>()
                    .Property(d => d.UnitPrice)
                    .HasColumnType("nvarchar")
                    .HasMaxLength(DataTypeHelpers.NAME_FIELD_LENGTH)
                    .IsRequired(true);

        modelBuilder.Entity<Drug>()
                    .Property(d => d.HealthInsurancePrice)
                    .HasColumnType("nvarchar")
                    .HasMaxLength(DataTypeHelpers.NAME_FIELD_LENGTH)
                    .IsRequired(true);

        modelBuilder.Entity<Drug>()
                    .Property(d => d.Country)
                    .HasColumnType("nvarchar")
                    .HasMaxLength(DataTypeHelpers.NAME_FIELD_LENGTH)
                    .IsRequired(true);

        modelBuilder.Entity<Drug>()
                    .Property(d => d.GroupId)
                    .HasColumnType("nvarchar")
                    .HasMaxLength(DataTypeHelpers.ID_FIELD_LENGTH)
                    .IsRequired(true);
    }
    private void DrugInventoryModelBuilder(ModelBuilder modelBuilder)
    {
        this.BaseModelBuilder<DrugInventory>(modelBuilder, nameof(DrugInventory));

        modelBuilder.Entity<DrugInventory>()
                    .Property(d => d.CurrentAmount)
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
                    .Property(d => d.GoodInformation)
                    .HasColumnType("nvarchar")
                    .HasMaxLength(DataTypeHelpers.DESCRIPTION_NAME_FIELD_LENGTH)
                    .IsRequired(false);

        modelBuilder.Entity<GoodSuppling>()
                    .Property(d => d.ExpiryDate)
                    .HasColumnType("datetime")
                    .IsRequired(true);

        modelBuilder.Entity<GoodSuppling>()
                    .Property(d => d.OrinaryAmount)
                    .HasColumnType("int")
                    .IsRequired(true);

        modelBuilder.Entity<GoodSuppling>()
                    .HasOne(di => di.Importation)
                    .WithMany(s => s.GoodSupplings)
                    .HasForeignKey(di => di.ImportationId)
                    .IsRequired(true)
                    .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<GoodSuppling>()
                    .HasOne(di => di.Inventory)
                    .WithOne(gs => gs.GoodSuppling)
                    .HasForeignKey<GoodSuppling>(di => di.InventoryId)
                    .IsRequired(true)
                    .OnDelete(DeleteBehavior.Cascade);
        
        modelBuilder.Entity<GoodSuppling>()
                    .HasOne(di => di.Drug)
                    .WithMany(s => s.GoodSupplings)
                    .HasForeignKey(di => di.DrugId)
                    .IsRequired(true)
                    .OnDelete(DeleteBehavior.Cascade);
    }
    private void ImportationModelBuilder(ModelBuilder modelBuilder)
    {
        this.BaseModelBuilder<Importation>(modelBuilder, nameof(Importation));

        modelBuilder.Entity<Importation>()
                    .Property(i => i.ReceiptNumber)
                    .HasColumnType("nvarchar")
                    .HasMaxLength(DataTypeHelpers.DESCRIPTION_NAME_FIELD_LENGTH)
                    .IsRequired(true);

        modelBuilder.Entity<Importation>()
                    .Property(i => i.Billnumber)
                    .HasColumnType("nvarchar")
                    .HasMaxLength(DataTypeHelpers.DESCRIPTION_NAME_FIELD_LENGTH)
                    .IsRequired(true);

        modelBuilder.Entity<Importation>()
                    .Property(i => i.RecordDay)
                    .HasColumnType("datetime")
                    .IsRequired(true);

        modelBuilder.Entity<Importation>()
                    .Property(i => i.ReceiptDay)
                    .HasColumnType("datetime")
                    .IsRequired(true);

        modelBuilder.Entity<Importation>()
                    .Property(i => i.Tax)
                    .HasColumnType("int")
                    .IsRequired(true);

        modelBuilder.Entity<Importation>()
                    .Property(i => i.TotalPrice)
                    .HasColumnType("int")
                    .IsRequired(true);

        modelBuilder.Entity<Importation>()
                    .Property(i => i.Company)
                    .HasColumnType("nvarchar")
                    .HasMaxLength(DataTypeHelpers.DESCRIPTION_NAME_FIELD_LENGTH)
                    .IsRequired(true);

        modelBuilder.Entity<Importation>()
                    .HasMany(i => i.GoodSupplings)
                    .WithOne(gs => gs.Importation)
                    .HasForeignKey(gs => gs.ImportationId)
                    .IsRequired(true)
                    .OnDelete(DeleteBehavior.Cascade);
    }
    private void StorageModelBuilder(ModelBuilder modelBuilder)
    {
        this.BaseModelBuilder<Storage>(modelBuilder, nameof(Storage));

        modelBuilder.Entity<Storage>()
                    .Property(s => s.Location)
                    .HasColumnType("nvarchar")
                    .HasMaxLength(DataTypeHelpers.ADDRESS_FIELD_LENGTH)
                    .IsRequired(true);

        modelBuilder.Entity<Storage>()
                    .HasMany(s => s.DrugInventories)
                    .WithOne(di => di.Storage)
                    .HasForeignKey(di => di.StorageId)
                    .IsRequired(true)
                    .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Storage>()
                    .HasMany(s => s.DeviceInventories)
                    .WithOne(di => di.Storage)
                    .HasForeignKey(di => di.StorageId)
                    .IsRequired(true)
                    .OnDelete(DeleteBehavior.Cascade);
    }
    private void DiagnosisModelBuilder(ModelBuilder modelBuilder)
    {
        this.BaseModelBuilder<Diagnosis>(modelBuilder, nameof(Diagnosis));

        modelBuilder.Entity<Diagnosis>()
                    .Property(s => s.DiagnosisCode)
                    .HasColumnType("nvarchar")
                    .HasMaxLength(DataTypeHelpers.ID_FIELD_LENGTH)
                    .IsRequired(true);

        modelBuilder.Entity<Diagnosis>()
                    .Property(s => s.Description)
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
                    .Property(s => s.ThresholdValue)
                    .HasColumnType("nvarchar")
                    .HasMaxLength(DataTypeHelpers.ID_FIELD_LENGTH)
                    .IsRequired(true);

        modelBuilder.Entity<DiagnosisSuggestion>()
                    .Property(s => s.IsActive)
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
                    .Property(s => s.Code)
                    .HasColumnType("nvarchar")
                    .HasMaxLength(DataTypeHelpers.ID_FIELD_LENGTH)
                    .IsRequired(true);

        modelBuilder.Entity<ICD>()
                    .Property(s => s.Description)
                    .HasColumnType("nvarchar")
                    .HasMaxLength(DataTypeHelpers.DESCRIPTION_NAME_FIELD_LENGTH)
                    .IsRequired(true);

        modelBuilder.Entity<ICD>()
                    .Property(s => s.Status)
                    .HasColumnType("nvarchar")
                    .HasConversion(new EnumToStringConverter<CodeStatus>())
                    .HasMaxLength(DataTypeHelpers.NAME_FIELD_LENGTH)
                    .IsRequired(true);
    }
    private void ICDDModelBuilder(ModelBuilder modelBuilder)
    {
        this.BaseModelBuilder<ICDD>(modelBuilder, nameof(ICDD));

        modelBuilder.Entity<ICDD>()
                    .Property(s => s.Code)
                    .HasColumnType("nvarchar")
                    .HasMaxLength(DataTypeHelpers.ID_FIELD_LENGTH)
                    .IsRequired(true);

        modelBuilder.Entity<ICDD>()
                    .Property(s => s.Description)
                    .HasColumnType("nvarchar")
                    .HasMaxLength(DataTypeHelpers.DESCRIPTION_NAME_FIELD_LENGTH)
                    .IsRequired(true);

        modelBuilder.Entity<ICDD>()
                    .Property(s => s.Status)
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
                    .Property(s => s.DateTakeExam)
                    .HasColumnType("datetime")
                    .IsRequired(true);

        modelBuilder.Entity<MedicalExamEposode>()
                    .Property(s => s.DateReExam)
                    .HasColumnType("datetime")
                    .IsRequired(true);

        modelBuilder.Entity<MedicalExamEposode>()
                    .Property(s => s.LineNumber)
                    .HasColumnType("int")
                    .IsRequired(true);

        modelBuilder.Entity<MedicalExamEposode>()
                    .HasOne(mee => mee.MedicalExam)
                    .WithMany(me => me.MedicalExamEposodes)
                    .HasForeignKey(mee => mee.MedicalExamId)
                    .IsRequired(true)
                    .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<MedicalExamEposode>()
                    .HasOne(mee => mee.ReExamAppointment)
                    .WithOne(rea => rea.MedicalExamEposode)
                    .HasForeignKey<MedicalExamEposode>(mee => mee.ReExamAppointmentId)
                    .IsRequired(true)
                    .OnDelete(DeleteBehavior.Cascade);
    }
    private void TreatmentModelBuilder(ModelBuilder modelBuilder)
    {
        this.BaseModelBuilder<Treatment>(modelBuilder, nameof(Treatment));

        modelBuilder.Entity<Treatment>()
                    .Property(s => s.TreatmentCode)
                    .HasColumnType("nvarchar")
                    .HasMaxLength(DataTypeHelpers.ID_FIELD_LENGTH)
                    .IsRequired(true);

        modelBuilder.Entity<Treatment>()
                    .Property(s => s.Description)
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
    private void DeviceServiceModelBuilder(ModelBuilder modelBuilder)
    {
        this.BaseModelBuilder<DeviceService>(modelBuilder, nameof(DeviceService));

        modelBuilder.Entity<DeviceService>()
                    .HasOne(t => t.DeviceInventory)
                    .WithMany(me => me.DeviceServices)
                    .HasForeignKey(t => t.DeviceInventoryId)
                    .IsRequired(true)
                    .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<DeviceService>()
                    .HasOne(t => t.Service)
                    .WithMany(i => i.DeviceServices)
                    .HasForeignKey(t => t.ServiceId)
                    .IsRequired(true)
                    .OnDelete(DeleteBehavior.Cascade);
    }
    private void MedicalDeviceModelBuilder(ModelBuilder modelBuilder)
    {
        this.BaseModelBuilder<MedicalDevice>(modelBuilder, nameof(MedicalDevice));

        modelBuilder.Entity<MedicalDevice>()
                    .Property(s => s.Name)
                    .HasColumnType("nvarchar")
                    .HasMaxLength(DataTypeHelpers.NAME_FIELD_LENGTH)
                    .IsRequired(true);

        modelBuilder.Entity<MedicalDevice>()
                    .Property(s => s.Country)
                    .HasColumnType("nvarchar")
                    .HasMaxLength(DataTypeHelpers.NAME_FIELD_LENGTH)
                    .IsRequired(true);

        modelBuilder.Entity<MedicalDevice>()
                    .Property(s => s.SmallID)
                    .HasColumnType("nvarchar")
                    .HasMaxLength(DataTypeHelpers.ID_FIELD_LENGTH)
                    .IsRequired(true);

        modelBuilder.Entity<MedicalDevice>()
                    .Property(s => s.GroupID)
                    .HasColumnType("nvarchar")
                    .HasMaxLength(DataTypeHelpers.ID_FIELD_LENGTH)
                    .IsRequired(true);

        modelBuilder.Entity<MedicalDevice>()
                    .Property(s => s.Min)
                    .HasColumnType("int")
                    .IsRequired(true);

        modelBuilder.Entity<MedicalDevice>()
                    .Property(s => s.Max)
                    .HasColumnType("int")
                    .IsRequired(true);
    }
    private void ServiceModelBuilder(ModelBuilder modelBuilder)
    {
        this.BaseModelBuilder<Service>(modelBuilder, nameof(Service));

        modelBuilder.Entity<Service>()
                    .Property(s => s.Name)
                    .HasColumnType("nvarchar")
                    .HasMaxLength(DataTypeHelpers.NAME_FIELD_LENGTH)
                    .IsRequired(true);

        modelBuilder.Entity<Service>()
                    .Property(s => s.Unit)
                    .HasColumnType("nvarchar")
                    .HasConversion(new EnumToStringConverter<Units>())
                    .HasMaxLength(DataTypeHelpers.NAME_FIELD_LENGTH)
                    .IsRequired(true);

        modelBuilder.Entity<Service>()
                    .Property(s => s.UnitPrice)
                    .HasColumnType("int")
                    .IsRequired(true);

        modelBuilder.Entity<Service>()
                    .Property(s => s.ServicePrice)
                    .HasColumnType("int")
                    .IsRequired(true);

        modelBuilder.Entity<Service>()
                    .Property(s => s.HealthInsurancePrice)
                    .HasColumnType("int")
                    .IsRequired(true);

        modelBuilder.Entity<Service>()
                    .Property(s => s.ResultFromType)
                    .HasColumnType("nvarchar")
                    .HasConversion(new EnumToStringConverter<FormTypes>())
                    .HasMaxLength(DataTypeHelpers.NAME_FIELD_LENGTH)
                    .IsRequired(true);
    }
    private void AnalysisTestModelBuilder(ModelBuilder modelBuilder)
    {
        this.BaseModelBuilder<AnalysisTest>(modelBuilder, nameof(AnalysisTest));

        modelBuilder.Entity<AnalysisTest>()
                    .Property(s => s.DSymptom)
                    .HasColumnType("nvarchar")
                    .HasMaxLength(DataTypeHelpers.NAME_FIELD_LENGTH)
                    .IsRequired(true);

        modelBuilder.Entity<AnalysisTest>()
                    .Property(s => s.DoctorComment)
                    .HasColumnType("nvarchar")
                    .HasMaxLength(DataTypeHelpers.DESCRIPTION_NAME_FIELD_LENGTH)
                    .IsRequired(true);

        modelBuilder.Entity<AnalysisTest>()
                    .Property(s => s.Result)
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
    private void BillModelBuilder(ModelBuilder modelBuilder)
    {
        this.BaseModelBuilder<Bill>(modelBuilder, nameof(Bill));

        modelBuilder.Entity<Bill>()
                    .Property(s => s.TotalDrugPrice)
                    .HasColumnType("int")
                    .IsRequired(true);

        modelBuilder.Entity<Bill>()
                    .Property(s => s.TotalServicePrice)
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
                    .Property(s => s.RecordDay)
                    .HasColumnType("datetime")
                    .IsRequired(true);

        modelBuilder.Entity<Transaction>()
                    .Property(s => s.TotalPrice)
                    .HasColumnType("int")
                    .IsRequired(true);

        modelBuilder.Entity<Transaction>()
                    .HasOne(dbd => dbd.MedicalExamEposode)
                    .WithMany(t => t.Transactions)
                    .HasForeignKey(dbd => dbd.MedicalExamEposodeId)
                    .IsRequired(true)
                    .OnDelete(DeleteBehavior.Cascade);
    }
    #endregion
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
}
