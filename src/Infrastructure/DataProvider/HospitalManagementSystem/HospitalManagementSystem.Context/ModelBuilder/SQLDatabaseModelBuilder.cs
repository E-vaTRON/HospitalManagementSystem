﻿namespace HospitalManagementSystem.DataProvider;

public class SQLDatabaseModelBuilder
{
    //using singleton for sqldatabase
    #region [ Singleton ]
    private static readonly Lazy<SQLDatabaseModelBuilder> sqlModel = new Lazy<SQLDatabaseModelBuilder>(
        () => new SQLDatabaseModelBuilder(), LazyThreadSafetyMode.PublicationOnly);
    public static SQLDatabaseModelBuilder SQLModel
    {
        get => sqlModel.Value;
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
        this.BookingAppointmentModelBuilder(modelBuilder);
        this.ReExamAppointmentModelBuilder(modelBuilder);
        this.ReferralModelBuilder(modelBuilder);
        this.ReferralDoctorModelBuilder(modelBuilder);

        this.RoomModelBuilder(modelBuilder);
        this.RoomAssignmentModelBuilder(modelBuilder);
        this.RoomAllocationModelBuilder(modelBuilder);
        this.DepartmentModelBuilder(modelBuilder);

        this.DeviceInventoryModelBuilder(modelBuilder);
        this.DrugModelBuilder(modelBuilder);
        this.DrugInventoryModelBuilder(modelBuilder);
        this.DrugPrescriptionModelBuilder(modelBuilder);
        this.GoodSupplingModelBuilder(modelBuilder);
        this.ImportationModelBuilder(modelBuilder);
        this.StorageModelBuilder(modelBuilder);

        this.AssignmentHistoryModelBuilder(modelBuilder);
        this.DiagnosisModelBuilder(modelBuilder);
        //this.DiagnosisSuggestionModelBuilder(modelBuilder);
        this.ICDModelBuilder(modelBuilder);
        this.MedicalExamModelBuilder(modelBuilder);
        this.MedicalExamEposodeModelBuilder(modelBuilder);
        this.TreatmentModelBuilder(modelBuilder);
        this.TreatmentExamEpisodeModelBuilder(modelBuilder);

        this.DeviceServiceModelBuilder(modelBuilder);
        this.MedicalDeviceModelBuilder(modelBuilder);
        this.ServiceModelBuilder(modelBuilder);
        this.AnalysisTestModelBuilder(modelBuilder);
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
                    .HasColumnType("uniqueidentifier")
                    .HasMaxLength(DataTypeHelpers.ID_FIELD_LENGTH)
                    .IsRequired(true);

        modelBuilder.Entity<TModel>()
                    .Property(x => x.CreatedOn)
                    .HasColumnType("datetime")
                    .IsRequired(true);

        modelBuilder.Entity<TModel>()
                    .Property(x => x.LastUpdatedOn)
                    .HasColumnType("datetime");


        modelBuilder.Entity<TModel>()
                    .Property(x => x.DeleteOn)
                    .HasColumnType("datetime");

        modelBuilder.Entity<TModel>()
                    .Property(x => x.IsDeleted)
                    .HasColumnType("bit")
                    .IsRequired(true);
    }
    #endregion

    #region [ Model Builder ]

    #region [ Function ]
    private void BookingAppointmentModelBuilder(ModelBuilder modelBuilder)
    {
        this.BaseModelBuilder<BookingAppointment>(modelBuilder, nameof(BookingAppointment));

        modelBuilder.Entity<BookingAppointment>()
                    .Property(x => x.AppointmentDate)
                    .HasColumnType("datetime")
                    .IsRequired(true);

        modelBuilder.Entity<BookingAppointment>()
                    .Property(x => x.Notes)
                    .HasColumnType("nvarchar");

        modelBuilder.Entity<BookingAppointment>()
                    .Property(x => x.PatientId)
                    .HasColumnType("nvarchar")
                    .IsRequired(true);

        modelBuilder.Entity<BookingAppointment>()
                    .Property(x => x.DoctorId)
                    .HasColumnType("nvarchar")
                    .IsRequired(true);

        modelBuilder.Entity<BookingAppointment>()
                    .HasOne(rd => rd.MedicalExam)
                    .WithOne(ah => ah.BookingAppointment)
                    .OnDelete(DeleteBehavior.Cascade);
    }
    private void ReExamAppointmentModelBuilder(ModelBuilder modelBuilder)
    {
        this.BaseModelBuilder<ReExamAppointment>(modelBuilder, nameof(ReExamAppointment));

        modelBuilder.Entity<ReExamAppointment>()
                    .Property(x => x.AppointmentDate)
                    .HasColumnType("datetime")
                    .IsRequired(true);

        modelBuilder.Entity<ReExamAppointment>()
                    .Property(x => x.Notes)
                    .HasColumnType("nvarchar");

        modelBuilder.Entity<ReExamAppointment>()
                    .Property(x => x.PatientId)
                    .HasColumnType("nvarchar");

        modelBuilder.Entity<ReExamAppointment>()
                    .HasOne(ra => ra.MedicalExamEposode)
                    .WithOne(mee => mee.ReExamAppointment)
                    .HasForeignKey<ReExamAppointment>(ra => ra.MedicalExamEposodeId);
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
                    .HasColumnType("nvarchar")
                    .HasMaxLength(DataTypeHelpers.DESCRIPTION_NAME_FIELD_LENGTH);

        modelBuilder.Entity<Referral>()
                    .Property(x => x.Urgency)
                    .HasColumnType("nvarchar")
                    .HasMaxLength(DataTypeHelpers.DESCRIPTION_NAME_FIELD_LENGTH);

        modelBuilder.Entity<Referral>()
                    .HasOne(r => r.MedicalExam)
                    .WithMany(d => d.Referrals)
                    .HasForeignKey(r => r.MedicalExamId)
                    .OnDelete(DeleteBehavior.Cascade);
    }
    private void ReferralDoctorModelBuilder(ModelBuilder modelBuilder)
    {
        this.BaseModelBuilder<ReferralDoctor>(modelBuilder, nameof(ReferralDoctor));

        modelBuilder.Entity<ReferralDoctor>()
                    .Property(x => x.ReferralStatus)
                    .HasColumnType("nvarchar");

        modelBuilder.Entity<ReferralDoctor>()
                    .Property(x => x.ReferredDoctorId)
                    .HasColumnType("nvarchar")
                    .IsRequired(true);

        modelBuilder.Entity<ReferralDoctor>()
                    .HasOne(rd => rd.Referral)
                    .WithMany(r => r.ReferralDoctors)
                    .HasForeignKey(rd => rd.ReferralId)
                    .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<ReferralDoctor>()
                    .HasOne(rd => rd.AssignmentHistory)
                    .WithOne(ah => ah.ReferralDoctor)
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
                    .HasMaxLength(DataTypeHelpers.NAME_FIELD_LENGTH);

        modelBuilder.Entity<Room>()
                    .Property(x => x.RoomType)
                    .HasColumnType("nvarchar")
                    .HasConversion(new EnumToStringConverter<RoomType>())
                    .HasMaxLength(DataTypeHelpers.TITLE_FIELD_LENGTH);

        modelBuilder.Entity<Room>()
                    .Property(x => x.Capacity)
                    .HasColumnType("int");

        modelBuilder.Entity<Room>()
                    .Property(x => x.Status)
                    .HasColumnType("nvarchar")
                    .HasConversion(new EnumToStringConverter<RoomStatus>())
                    .HasMaxLength(DataTypeHelpers.TITLE_FIELD_LENGTH);

        modelBuilder.Entity<Room>()
                    .HasOne(r => r.Department)
                    .WithMany(d => d.Rooms)
                    .HasForeignKey(r => r.DepartmentId)
                    .OnDelete(DeleteBehavior.Cascade);
    }
    private void RoomAssignmentModelBuilder(ModelBuilder modelBuilder)
    {
        this.BaseModelBuilder<RoomAssignment>(modelBuilder, nameof(RoomAssignment));

        modelBuilder.Entity<RoomAssignment>()
                    .Property(x => x.StartTime)
                    .HasColumnType("datetime");

        modelBuilder.Entity<RoomAssignment>()
                    .Property(x => x.EndTime)
                    .HasColumnType("datetime");

        modelBuilder.Entity<RoomAssignment>()
                    .Property(x => x.EmployeeId)
                    .HasColumnType("nvarchar")
                    .IsRequired(true);

        modelBuilder.Entity<RoomAssignment>()
                    .HasOne(ra => ra.Room)
                    .WithMany(r => r.RoomAssignments)
                    .HasForeignKey(ra => ra.RoomId)
                    .OnDelete(DeleteBehavior.Cascade);
    }
    private void RoomAllocationModelBuilder(ModelBuilder modelBuilder)
    {
        this.BaseModelBuilder<RoomAllocation>(modelBuilder, nameof(RoomAllocation));

        modelBuilder.Entity<RoomAllocation>()
                    .Property(x => x.StartTime)
                    .HasColumnType("datetime");

        modelBuilder.Entity<RoomAllocation>()
                    .Property(x => x.EndTime)
                    .HasColumnType("datetime");

        modelBuilder.Entity<RoomAllocation>()
                    .Property(x => x.PatientId)
                    .HasColumnType("nvarchar")
                    .IsRequired(true);

        modelBuilder.Entity<RoomAllocation>()
                    .HasOne(ra => ra.Room)
                    .WithMany(r => r.RoomAllocations)
                    .HasForeignKey(ra => ra.RoomId)
                    .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<RoomAllocation>()
                    .HasOne(ra => ra.MedicalExamEposode)
                    .WithMany(mee => mee.RoomAllocations)
                    .HasForeignKey(ra => ra.MedicalExamEposodeId)
                    .OnDelete(DeleteBehavior.Cascade);
    }
    private void DepartmentModelBuilder(ModelBuilder modelBuilder)
    {
        this.BaseModelBuilder<Department>(modelBuilder, nameof(Department));

        modelBuilder.Entity<Department>()
                    .Property(x => x.Name)
                    .HasColumnType("nvarchar")
                    .HasMaxLength(DataTypeHelpers.NAME_FIELD_LENGTH);
    }
    #endregion

    #region [ Inventory ]
    private void DeviceInventoryModelBuilder(ModelBuilder modelBuilder)
    {
        this.BaseModelBuilder<DeviceInventory>(modelBuilder, nameof(DeviceInventory));

        modelBuilder.Entity<DeviceInventory>()
                    .Property(x => x.CurrentAmount)
                    .HasColumnType("int");

        modelBuilder.Entity<DeviceInventory>()
                    .HasOne(di => di.MedicalDevice)
                    .WithMany(md => md.DeviceInventorys)
                    .HasForeignKey(di => di.MedicalDeviceId)
                    .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<DeviceInventory>()
                    .HasOne(di => di.Storage)
                    .WithMany(s => s.DeviceInventories)
                    .HasForeignKey(di => di.StorageId)
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
                    .HasMaxLength(DataTypeHelpers.NAME_FIELD_LENGTH);

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
                    .HasMaxLength(DataTypeHelpers.ID_FIELD_LENGTH);
    }
    private void DrugInventoryModelBuilder(ModelBuilder modelBuilder)
    {
        this.BaseModelBuilder<DrugInventory>(modelBuilder, nameof(DrugInventory));

        modelBuilder.Entity<DrugInventory>()
                    .Property(x => x.CurrentAmount)
                    .HasColumnType("int");

        modelBuilder.Entity<DrugInventory>()
                    .HasOne(di => di.Storage)
                    .WithMany(s => s.DrugInventories)
                    .HasForeignKey(di => di.StorageId)
                    .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<DrugInventory>()
                    .HasOne(di => di.GoodSuppling)
                    .WithOne(gs => gs.DrugInventory)
                    .HasForeignKey<DrugInventory>(di => di.GoodSupplingId);
    }
    private void DrugPrescriptionModelBuilder(ModelBuilder modelBuilder)
    {
        this.BaseModelBuilder<DrugPrescription>(modelBuilder, nameof(DrugPrescription));

        modelBuilder.Entity<DrugPrescription>()
                    .HasOne(dd => dd.MedicalExamEposode)
                    .WithMany(mee => mee.DrugPrescriptions)
                    .HasForeignKey(dd => dd.MedicalExamEposodeId)
                    .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<DrugPrescription>()
                    .HasOne(dd => dd.DrugInventory)
                    .WithMany(di => di.DrugPrescriptions)
                    .HasForeignKey(dd => dd.DrugInventoryId)
                    .OnDelete(DeleteBehavior.Cascade);
    }
    private void GoodSupplingModelBuilder(ModelBuilder modelBuilder)
    {
        this.BaseModelBuilder<GoodSuppling>(modelBuilder, nameof(GoodSuppling));

        modelBuilder.Entity<GoodSuppling>()
                    .Property(x => x.GoodInformation)
                    .HasColumnType("nvarchar")
                    .HasMaxLength(DataTypeHelpers.DESCRIPTION_NAME_FIELD_LENGTH);

        modelBuilder.Entity<GoodSuppling>()
                    .Property(x => x.ExpiryDate)
                    .HasColumnType("datetime")
                    .IsRequired(true);

        modelBuilder.Entity<GoodSuppling>()
                    .Property(x => x.OrinaryAmount)
                    .HasColumnType("int");

        modelBuilder.Entity<GoodSuppling>()
                    .HasOne(gs => gs.Importation)
                    .WithMany(i => i.GoodSupplings)
                    .HasForeignKey(gs => gs.ImportationId)
                    .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<GoodSuppling>()
                    .HasOne(gs => gs.DrugInventory)
                    .WithOne(i => i.GoodSuppling)
                    .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<GoodSuppling>()
                    .HasOne(gs => gs.Drug)
                    .WithMany(d => d.GoodSupplings)
                    .HasForeignKey(gs => gs.DrugId)
                    .OnDelete(DeleteBehavior.Cascade);
    }
    private void ImportationModelBuilder(ModelBuilder modelBuilder)
    {
        this.BaseModelBuilder<Importation>(modelBuilder, nameof(Importation));

        modelBuilder.Entity<Importation>()
                    .Property(x => x.ReceiptNumber)
                    .HasColumnType("nvarchar")
                    .HasMaxLength(DataTypeHelpers.DESCRIPTION_NAME_FIELD_LENGTH);

        modelBuilder.Entity<Importation>()
                    .Property(x => x.Billnumber)
                    .HasColumnType("nvarchar")
                    .HasMaxLength(DataTypeHelpers.DESCRIPTION_NAME_FIELD_LENGTH);

        modelBuilder.Entity<Importation>()
                    .Property(x => x.RecordDay)
                    .HasColumnType("datetime")
                    .IsRequired(true);

        modelBuilder.Entity<Importation>()
                    .Property(x => x.ReceiptDay)
                    .HasColumnType("datetime");

        modelBuilder.Entity<Importation>()
                    .Property(x => x.Tax)
                    .HasColumnType("int");

        modelBuilder.Entity<Importation>()
                    .Property(x => x.TotalPrice)
                    .HasColumnType("int");

        modelBuilder.Entity<Importation>()
                    .Property(x => x.Company)
                    .HasColumnType("nvarchar")
                    .HasMaxLength(DataTypeHelpers.DESCRIPTION_NAME_FIELD_LENGTH);
    }
    private void StorageModelBuilder(ModelBuilder modelBuilder)
    {
        this.BaseModelBuilder<Storage>(modelBuilder, nameof(Storage));

        modelBuilder.Entity<Storage>()
                    .Property(x => x.Location)
                    .HasColumnType("nvarchar")
                    .HasMaxLength(DataTypeHelpers.ADDRESS_FIELD_LENGTH);
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
                    .Property(x => x.DoctorId)
                    .HasColumnType("nvarchar")
                    .IsRequired(true);

        modelBuilder.Entity<AssignmentHistory>()
                    .HasOne(rd => rd.MedicalExamEposode)
                    .WithMany(mee => mee.AssignmentHistories)
                    .HasForeignKey(rd => rd.MedicalExamEposodeId)
                    .IsRequired(true)
                    .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<AssignmentHistory>()
                    .HasOne(ah => ah.ReferralDoctor)
                    .WithOne(rd => rd.AssignmentHistory)
                    .HasForeignKey<AssignmentHistory>(ah => ah.ReferralDoctorId)
                    .IsRequired(false);
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
                    .HasMaxLength(DataTypeHelpers.DESCRIPTION_NAME_FIELD_LENGTH);

        modelBuilder.Entity<Diagnosis>()
                    .HasOne(t => t.ICD)
                    .WithMany(i => i.Diagnoses)
                    .HasForeignKey(t => t.ICDId)
                    .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Diagnosis>()
                    .HasOne(t => t.MedicalExamEposode)
                    .WithMany(i => i.Diagnoses)
                    .HasForeignKey(t => t.MedicalExamEpisodeId)
                    .OnDelete(DeleteBehavior.Cascade);
    }
    //private void DiagnosisSuggestionModelBuilder(ModelBuilder modelBuilder)  // Bản này có thể không tạo
    //{
    //    this.BaseModelBuilder<DiagnosisSuggestion>(modelBuilder, nameof(DiagnosisSuggestion));

    //    modelBuilder.Entity<DiagnosisSuggestion>()
    //                .Property(x => x.ThresholdValue)
    //                .HasColumnType("nvarchar")
    //                .HasMaxLength(DataTypeHelpers.ID_FIELD_LENGTH)
    //                .IsRequired(true);

    //    modelBuilder.Entity<DiagnosisSuggestion>()
    //                .Property(x => x.IsActive)
    //                .HasColumnType("bit")
    //                .IsRequired(true);

    //    modelBuilder.Entity<DiagnosisSuggestion>()
    //                .HasOne(ds => ds.AnalysisTest)
    //                .WithMany(a => a.DiagnosisSuggestions)
    //                .HasForeignKey(ds => ds.AnalysisTestId);

    //    modelBuilder.Entity<DiagnosisSuggestion>()
    //                .HasOne(ds => ds.Diagnosis)
    //                .WithMany(d => d.DiagnosisSuggestions)
    //                .HasForeignKey(ds => ds.DiagnosisId);
    //}
    
    private void ICDModelBuilder(ModelBuilder modelBuilder)
    {
        this.BaseModelBuilder<Diseases>(modelBuilder, nameof(Diseases));

        modelBuilder.Entity<Diseases>()
                    .Property(x => x.Code)
                    .HasColumnType("nvarchar")
                    .HasMaxLength(DataTypeHelpers.ID_FIELD_LENGTH)
                    .IsRequired(true);

        modelBuilder.Entity<Diseases>()
                    .Property(x => x.Description)
                    .HasColumnType("nvarchar")
                    .HasMaxLength(DataTypeHelpers.DESCRIPTION_NAME_FIELD_LENGTH);

        modelBuilder.Entity<Diseases>()
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
                    .Property(x => x.FinalPrice)
                    .HasColumnType("int");

        modelBuilder.Entity<MedicalExam>()
                    .HasOne(me => me.BookingAppointment)
                    .WithOne(ba => ba.MedicalExam)
                    .HasForeignKey<MedicalExam>(me => me.BookingAppointmentId)
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
                    .HasColumnType("datetime");

        modelBuilder.Entity<MedicalExamEposode>()
                    .Property(x => x.LineNumber)
                    .HasColumnType("int");

        modelBuilder.Entity<MedicalExamEposode>()
                    .Property(x => x.RecordDay)
                    .HasColumnType("datetime");

        modelBuilder.Entity<MedicalExamEposode>()
                    .Property(x => x.TotalPrice)
                    .HasColumnType("int");

        modelBuilder.Entity<MedicalExamEposode>()
                    .HasOne(rd => rd.ReExamAppointment)
                    .WithOne(ah => ah.MedicalExamEposode)
                    .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<MedicalExamEposode>()
                    .HasOne(mee => mee.MedicalExam)
                    .WithMany(me => me.MedicalExamEposodes)
                    .HasForeignKey(mee => mee.MedicalExamId)
                    .OnDelete(DeleteBehavior.Cascade);

    }
    private void TreatmentModelBuilder(ModelBuilder modelBuilder)
    {
        this.BaseModelBuilder<Treatment>(modelBuilder, nameof(Treatment));

        modelBuilder.Entity<Treatment>()
                    .Property(x => x.Name)
                    .HasColumnType("nvarchar")
                    .HasMaxLength(DataTypeHelpers.ID_FIELD_LENGTH);

        modelBuilder.Entity<Treatment>()
                    .Property(x => x.Description)
                    .HasColumnType("nvarchar")
                    .HasMaxLength(DataTypeHelpers.DESCRIPTION_NAME_FIELD_LENGTH);
    }
    private void TreatmentExamEpisodeModelBuilder(ModelBuilder modelBuilder)
    {
        this.BaseModelBuilder<TreatmentExamEpisode>(modelBuilder, nameof(TreatmentExamEpisode));

        modelBuilder.Entity<TreatmentExamEpisode>()
                    .HasOne(tee => tee.Treatment)
                    .WithMany(t => t.TreatmentExamEpisodes)
                    .HasForeignKey(tee => tee.TreatmentId)
                    .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<TreatmentExamEpisode>()
                    .HasOne(tee => tee.MedicalExamEposode)
                    .WithMany(mee => mee.TreatmentExamEpisodes)
                    .HasForeignKey(tee => tee.MedicalExamEpisodeId)
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
                    .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<DeviceService>()
                    .HasOne(ds => ds.Service)
                    .WithMany(s => s.DeviceServices)
                    .HasForeignKey(ds => ds.ServiceId)
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
                    .HasMaxLength(DataTypeHelpers.NAME_FIELD_LENGTH);

        modelBuilder.Entity<MedicalDevice>()
                    .Property(x => x.SmallID)
                    .HasColumnType("nvarchar")
                    .HasMaxLength(DataTypeHelpers.ID_FIELD_LENGTH);

        modelBuilder.Entity<MedicalDevice>()
                    .Property(x => x.GroupID)
                    .HasColumnType("nvarchar")
                    .HasMaxLength(DataTypeHelpers.ID_FIELD_LENGTH);

        modelBuilder.Entity<MedicalDevice>()
                    .Property(x => x.Min)
                    .HasColumnType("int");

        modelBuilder.Entity<MedicalDevice>()
                    .Property(x => x.Max)
                    .HasColumnType("int");
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
                    .HasColumnType("int");

        modelBuilder.Entity<Service>()
                    .Property(x => x.ServicePrice)
                    .HasColumnType("int");

        modelBuilder.Entity<Service>()
                    .Property(x => x.HealthInsurancePrice)
                    .HasColumnType("int");

        modelBuilder.Entity<Service>()
                    .Property(x => x.ResultFromType)
                    .HasColumnType("nvarchar")
                    .HasConversion(new EnumToStringConverter<FormTypes>())
                    .HasMaxLength(DataTypeHelpers.NAME_FIELD_LENGTH);
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
                    .HasMaxLength(DataTypeHelpers.DESCRIPTION_NAME_FIELD_LENGTH);

        modelBuilder.Entity<AnalysisTest>()
                    .Property(x => x.Result)
                    .HasColumnType("nvarchar")
                    .HasMaxLength(DataTypeHelpers.DESCRIPTION_NAME_FIELD_LENGTH);

        modelBuilder.Entity<AnalysisTest>()
                    .HasOne(at => at.DeviceService)
                    .WithMany(ds => ds.AnalysisTests)
                    .HasForeignKey(at => at.DeviceServiceId)
                    .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<AnalysisTest>()
                    .HasOne(at => at.MedicalExamEposode)
                    .WithMany(mee => mee.AnalysisTests)
                    .HasForeignKey(at => at.MedicalExamEposodeId)
                    .OnDelete(DeleteBehavior.Cascade);
    }
    #endregion

    #endregion
}
