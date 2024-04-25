﻿namespace HospitalManagementSystem.DataProvider;

public class SQLiteDatabaseModelBuilder
{
    #region [ Singleton ]
    private static readonly Lazy<SQLiteDatabaseModelBuilder> sqliteModel = new Lazy<SQLiteDatabaseModelBuilder>(() => new SQLiteDatabaseModelBuilder(), LazyThreadSafetyMode.PublicationOnly);
    public static SQLiteDatabaseModelBuilder SQLiteModel
    {
        get { return sqliteModel.Value; }
    }
    #endregion

    #region [ CTor ]
    public SQLiteDatabaseModelBuilder() { }
    #endregion

    #region [ Public Methods ]
    public Microsoft.EntityFrameworkCore.Metadata.IModel GetModel()
    {
        var builder = new ModelBuilder();

        this.CreateModels(builder);

        return builder.FinalizeModel();
    }
    #endregion

    #region [ Private Methods ]
    private void CreateModels(ModelBuilder modelBuilder)
    {
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
                    .HasColumnType("TEXT")
                    .IsRequired(true);

        modelBuilder.Entity<TModel>()
                    .Property(x => x.CreatedOn)
                    .HasColumnType("TEXT")
                    .IsRequired(true);

        modelBuilder.Entity<TModel>()
                    .Property(x => x.LastUpdatedOn)
                    .HasColumnType("TEXT");

        modelBuilder.Entity<TModel>()
                    .Property(x => x.DeleteOn)
                    .HasColumnType("TEXT");

        modelBuilder.Entity<TModel>()
                    .Property(x => x.IsDeleted)
                    .HasColumnType("INTEGER")
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
                    .HasColumnType("TEXT")
                    .IsRequired(true);

        modelBuilder.Entity<BookingAppointment>()
                    .Property(x => x.Notes)
                    .HasColumnType("TEXT");

        modelBuilder.Entity<BookingAppointment>()
                    .Property(x => x.PatientId)
                    .HasColumnType("TEXT")
                    .IsRequired(true);

        modelBuilder.Entity<BookingAppointment>()
                    .Property(x => x.DoctorId)
                    .HasColumnType("TEXT")
                    .IsRequired(true);

        modelBuilder.Entity<BookingAppointment>()
                    .HasOne(rd => rd.MedicalExam)
                    .WithOne(ah => ah.BookingAppointment);
    }

    private void ReExamAppointmentModelBuilder(ModelBuilder modelBuilder)
    {
        this.BaseModelBuilder<ReExamAppointment>(modelBuilder, nameof(ReExamAppointment));

        modelBuilder.Entity<ReExamAppointment>()
                    .Property(x => x.AppointmentDate)
                    .HasColumnType("TEXT")
                    .IsRequired(true);

        modelBuilder.Entity<ReExamAppointment>()
                    .Property(x => x.Notes)
                    .HasColumnType("TEXT");

        modelBuilder.Entity<ReExamAppointment>()
                    .Property(x => x.PatientId)
                    .HasColumnType("TEXT");

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
                    .HasColumnType("TEXT")
                    .IsRequired(true);

        modelBuilder.Entity<Referral>()
                    .Property(x => x.Reason)
                    .HasColumnType("TEXT");

        modelBuilder.Entity<Referral>()
                    .Property(x => x.Urgency)
                    .HasColumnType("TEXT");

        modelBuilder.Entity<Referral>()
                    .HasOne(r => r.MedicalExam)
                    .WithMany(d => d.Referrals)
                    .HasForeignKey(r => r.MedicalExamId);
    }

    private void ReferralDoctorModelBuilder(ModelBuilder modelBuilder)
    {
        this.BaseModelBuilder<ReferralDoctor>(modelBuilder, nameof(ReferralDoctor));

        modelBuilder.Entity<ReferralDoctor>()
                    .Property(x => x.ReferralStatus)
                    .HasColumnType("TEXT");

        modelBuilder.Entity<ReferralDoctor>()
                    .Property(x => x.ReferredDoctorId)
                    .HasColumnType("TEXT")
                    .IsRequired(true);

        modelBuilder.Entity<ReferralDoctor>()
                    .HasOne(rd => rd.Referral)
                    .WithMany(r => r.ReferralDoctors)
                    .HasForeignKey(rd => rd.ReferralId);

        modelBuilder.Entity<ReferralDoctor>()
                    .HasOne(rd => rd.AssignmentHistory)
                    .WithOne(ah => ah.ReferralDoctor);
    }
    #endregion

    #region [ Infrastructure ]
    private void RoomModelBuilder(ModelBuilder modelBuilder)
    {
        this.BaseModelBuilder<Room>(modelBuilder, nameof(Room));

        modelBuilder.Entity<Room>()
                    .Property(x => x.Name)
                    .HasColumnType("TEXT");

        modelBuilder.Entity<Room>()
                    .Property(x => x.RoomType)
                    .HasColumnType("TEXT");

        modelBuilder.Entity<Room>()
                    .Property(x => x.Capacity)
                    .HasColumnType("INTEGER");

        modelBuilder.Entity<Room>()
                    .Property(x => x.Status)
                    .HasColumnType("TEXT");

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
                    .HasColumnType("TEXT");

        modelBuilder.Entity<RoomAssignment>()
                    .Property(x => x.EndTime)
                    .HasColumnType("TEXT");

        modelBuilder.Entity<RoomAssignment>()
                    .Property(x => x.EmployeeId)
                    .HasColumnType("TEXT")
                    .IsRequired(true);

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
                    .HasColumnType("TEXT");

        modelBuilder.Entity<RoomAllocation>()
                    .Property(x => x.EndTime)
                    .HasColumnType("TEXT");

        modelBuilder.Entity<RoomAllocation>()
                    .Property(x => x.PatientId)
                    .HasColumnType("TEXT")
                    .IsRequired(true);

        modelBuilder.Entity<RoomAllocation>()
                    .HasOne(ra => ra.Room)
                    .WithMany(r => r.RoomAllocations)
                    .HasForeignKey(ra => ra.RoomId);

        modelBuilder.Entity<RoomAllocation>()
                    .HasOne(ra => ra.MedicalExamEposode)
                    .WithMany(mee => mee.RoomAllocations)
                    .HasForeignKey(ra => ra.MedicalExamEposodeId);
    }
    private void DepartmentModelBuilder(ModelBuilder modelBuilder)
    {
        this.BaseModelBuilder<Department>(modelBuilder, nameof(Department));

        modelBuilder.Entity<Department>()
                    .Property(x => x.Name)
                    .HasColumnType("TEXT");
    }
    #endregion

    #region [ Inventory ]
    private void DeviceInventoryModelBuilder(ModelBuilder modelBuilder)
    {
        this.BaseModelBuilder<DeviceInventory>(modelBuilder, nameof(DeviceInventory));

        modelBuilder.Entity<DeviceInventory>()
                    .Property(x => x.CurrentAmount)
                    .HasColumnType("INTEGER");

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
                    .Property(x => x.GoodName)
                    .HasColumnType("TEXT")
                    .IsRequired(true);

        modelBuilder.Entity<Drug>()
                    .Property(x => x.ActiveIngredientName)
                    .HasColumnType("TEXT");

        modelBuilder.Entity<Drug>()
                    .Property(x => x.Unit)
                    .HasColumnType("TEXT")
                    .IsRequired(true);

        modelBuilder.Entity<Drug>()
                    .Property(x => x.GoodType)
                    .HasColumnType("TEXT")
                    .IsRequired(true);

        modelBuilder.Entity<Drug>()
                    .Property(x => x.UnitPrice)
                    .HasColumnType("TEXT")
                    .IsRequired(true);

        modelBuilder.Entity<Drug>()
                    .Property(x => x.HealthInsurancePrice)
                    .HasColumnType("TEXT")
                    .IsRequired(true);

        modelBuilder.Entity<Drug>()
                    .Property(x => x.Country)
                    .HasColumnType("TEXT")
                    .IsRequired(true);

        modelBuilder.Entity<Drug>()
                    .Property(x => x.GroupId)
                    .HasColumnType("TEXT");
    }
    private void DrugInventoryModelBuilder(ModelBuilder modelBuilder)
    {
        this.BaseModelBuilder<DrugInventory>(modelBuilder, nameof(DrugInventory));

        modelBuilder.Entity<DrugInventory>()
                    .Property(x => x.CurrentAmount)
                    .HasColumnType("INTEGER");

        modelBuilder.Entity<DrugInventory>()
                    .HasOne(di => di.Storage)
                    .WithMany(s => s.DrugInventories)
                    .HasForeignKey(di => di.StorageId);

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
                    .HasForeignKey(dd => dd.MedicalExamEposodeId);

        modelBuilder.Entity<DrugPrescription>()
                    .HasOne(dd => dd.DrugInventory)
                    .WithMany(di => di.DrugPrescriptions)
                    .HasForeignKey(dd => dd.DrugInventoryId);
    }
    private void GoodSupplingModelBuilder(ModelBuilder modelBuilder)
    {
        this.BaseModelBuilder<GoodSuppling>(modelBuilder, nameof(GoodSuppling));

        modelBuilder.Entity<GoodSuppling>()
                    .Property(x => x.GoodInformation)
                    .HasColumnType("TEXT");

        modelBuilder.Entity<GoodSuppling>()
                    .Property(x => x.ExpiryDate)
                    .HasColumnType("TEXT")
                    .IsRequired(true);

        modelBuilder.Entity<GoodSuppling>()
                    .Property(x => x.OrinaryAmount)
                    .HasColumnType("INTEGER");

        modelBuilder.Entity<GoodSuppling>()
                    .HasOne(gs => gs.Importation)
                    .WithMany(i => i.GoodSupplings)
                    .HasForeignKey(gs => gs.ImportationId);

        modelBuilder.Entity<GoodSuppling>()
                    .HasOne(gs => gs.DrugInventory)
                    .WithOne(i => i.GoodSuppling);

        modelBuilder.Entity<GoodSuppling>()
                    .HasOne(gs => gs.Drug)
                    .WithMany(d => d.GoodSupplings)
                    .HasForeignKey(gs => gs.DrugId);
    }
    private void ImportationModelBuilder(ModelBuilder modelBuilder)
    {
        this.BaseModelBuilder<Importation>(modelBuilder, nameof(Importation));

        modelBuilder.Entity<Importation>()
                    .Property(x => x.ReceiptNumber)
                    .HasColumnType("TEXT");

        modelBuilder.Entity<Importation>()
                    .Property(x => x.Billnumber)
                    .HasColumnType("TEXT");

        modelBuilder.Entity<Importation>()
                    .Property(x => x.RecordDay)
                    .HasColumnType("TEXT")
                    .IsRequired(true);

        modelBuilder.Entity<Importation>()
                    .Property(x => x.ReceiptDay)
                    .HasColumnType("TEXT");

        modelBuilder.Entity<Importation>()
                    .Property(x => x.Tax)
                    .HasColumnType("INTEGER");

        modelBuilder.Entity<Importation>()
                    .Property(x => x.TotalPrice)
                    .HasColumnType("INTEGER");

        modelBuilder.Entity<Importation>()
                    .Property(x => x.Company)
                    .HasColumnType("TEXT");
    }
    private void StorageModelBuilder(ModelBuilder modelBuilder)
    {
        this.BaseModelBuilder<Storage>(modelBuilder, nameof(Storage));

        modelBuilder.Entity<Storage>()
                    .Property(x => x.Location)
                    .HasColumnType("TEXT");
    }
    #endregion

    #region [ Medical ]
    private void AssignmentHistoryModelBuilder(ModelBuilder modelBuilder)
    {
        this.BaseModelBuilder<AssignmentHistory>(modelBuilder, nameof(AssignmentHistory));

        modelBuilder.Entity<AssignmentHistory>()
                    .Property(x => x.AssignmentStatus)
                    .HasColumnType("TEXT")
                    .IsRequired(true);

        modelBuilder.Entity<AssignmentHistory>()
                    .Property(x => x.DoctorId)
                    .HasColumnType("TEXT")
                    .IsRequired(true);

        modelBuilder.Entity<AssignmentHistory>()
                    .HasOne(rd => rd.MedicalExamEposode)
                    .WithMany(mee => mee.AssignmentHistories)
                    .HasForeignKey(rd => rd.MedicalExamEposodeId)
                    .IsRequired(true);

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
                    .HasColumnType("TEXT")
                    .IsRequired(true);

        modelBuilder.Entity<Diagnosis>()
                    .Property(x => x.Description)
                    .HasColumnType("TEXT");

        modelBuilder.Entity<Diagnosis>()
                    .HasOne(t => t.ICD)
                    .WithMany(i => i.Diagnoses)
                    .HasForeignKey(t => t.ICDId);
    }

    private void DiagnosisTreatmentModelBuilder(ModelBuilder modelBuilder)
    {
        this.BaseModelBuilder<DiagnosisTreatment>(modelBuilder, nameof(DiagnosisTreatment));

        modelBuilder.Entity<DiagnosisTreatment>()
                    .HasOne(dt => dt.Treatment)
                    .WithMany(t => t.DiagnosisTreatments)
                    .HasForeignKey(dt => dt.TreatmentId);

        modelBuilder.Entity<DiagnosisTreatment>()
                    .HasOne(dt => dt.Diagnosis)
                    .WithMany(d => d.DiagnosisTreatments)
                    .HasForeignKey(dt => dt.DiagnosisId);
    }
    private void ICDModelBuilder(ModelBuilder modelBuilder)
    {
        this.BaseModelBuilder<ICD>(modelBuilder, nameof(ICD));

        modelBuilder.Entity<ICD>()
                    .Property(x => x.Code)
                    .HasColumnType("TEXT")
                    .IsRequired(true);

        modelBuilder.Entity<ICD>()
                    .Property(x => x.Description)
                    .HasColumnType("TEXT");

        modelBuilder.Entity<ICD>()
                    .Property(x => x.Status)
                    .HasColumnType("TEXT")
                    .IsRequired(true);
    }
    private void MedicalExamModelBuilder(ModelBuilder modelBuilder)
    {
        this.BaseModelBuilder<MedicalExam>(modelBuilder, nameof(MedicalExam));

        modelBuilder.Entity<MedicalExam>()
                    .Property(x => x.FinalPrice)
                    .HasColumnType("INTEGER");

        modelBuilder.Entity<MedicalExam>()
                    .HasOne(me => me.BookingAppointment)
                    .WithOne(ba => ba.MedicalExam)
                    .HasForeignKey<MedicalExam>(me => me.BookingAppointmentId);

        modelBuilder.Entity<MedicalExam>()
                    .HasOne(me => me.BookingAppointment)
                    .WithOne(ba => ba.MedicalExam)
                    .HasForeignKey<MedicalExam>(me => me.BookingAppointmentId);
    }
    private void MedicalExamEposodeModelBuilder(ModelBuilder modelBuilder)
    {
        this.BaseModelBuilder<MedicalExamEposode>(modelBuilder, nameof(MedicalExamEposode));

        modelBuilder.Entity<MedicalExamEposode>()
                    .Property(x => x.DateTakeExam)
                    .HasColumnType("TEXT")
                    .IsRequired(true);

        modelBuilder.Entity<MedicalExamEposode>()
                    .Property(x => x.DateReExam)
                    .HasColumnType("TEXT");

        modelBuilder.Entity<MedicalExamEposode>()
                    .Property(x => x.LineNumber)
                    .HasColumnType("INTEGER");

        modelBuilder.Entity<MedicalExamEposode>()
                    .Property(x => x.RecordDay)
                    .HasColumnType("TEXT");

        modelBuilder.Entity<MedicalExamEposode>()
                    .Property(x => x.TotalPrice)
                    .HasColumnType("INTEGER");

        modelBuilder.Entity<MedicalExamEposode>()
                    .HasOne(rd => rd.ReExamAppointment)
                    .WithOne(ah => ah.MedicalExamEposode);

        modelBuilder.Entity<MedicalExamEposode>()
                    .HasOne(mee => mee.MedicalExam)
                    .WithMany(me => me.MedicalExamEposodes)
                    .HasForeignKey(mee => mee.MedicalExamId);

    }
    private void TreatmentModelBuilder(ModelBuilder modelBuilder)
    {
        this.BaseModelBuilder<Treatment>(modelBuilder, nameof(Treatment));

        modelBuilder.Entity<Treatment>()
                    .Property(x => x.Name)
                    .HasColumnType("TEXT");

        modelBuilder.Entity<Treatment>()
                    .Property(x => x.Description)
                    .HasColumnType("TEXT");
    }
    #endregion

    #endregion
}
