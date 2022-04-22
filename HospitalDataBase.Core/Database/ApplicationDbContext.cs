using Core.Entities.UserIdentifile;
using HospitalDataBase.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HospitalDataBase.Core.Database
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public virtual DbSet<AnalysationTest>               AnalysationTests        { get; set; } = null!;
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

            builder.Entity<User>(entity =>
            {
                entity.Property(e => e.Guid).HasDefaultValueSql("NEWID()");
                entity.HasIndex(e => e.Guid).IsUnique();
            });

            builder.Entity<UserRole>(entity =>
            {
                entity.HasOne(ur => ur.Role)
                      .WithMany(r => r!.UserRoles)
                      .HasForeignKey(ur => ur.ID)
                      .IsRequired().OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(ur => ur.User)
                      .WithMany(u => u!.UserRoles)
                      .HasForeignKey(ur => ur.ID)
                      .IsRequired().OnDelete(DeleteBehavior.Cascade);
            });

            builder.Entity<Inventory>(entity =>
            {

                entity.HasOne(i => i.Storage)
                      .WithMany(d => d!.Inventories)
                      .HasForeignKey(i => i!.StorageID)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            builder.Entity<PatientTransactionHistory>(entity =>
            {
                entity.HasOne(p => p.Exam)
                      .WithOne(e => e.Transaction)
                      .HasForeignKey<HistoryMedicalExam>(e => e.TransactionID)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            builder.Entity<HistoryMedicalExam>(entity =>
            {
                entity.HasOne(h => h.Patient)
                      .WithMany(p => p!.Exams)
                      .HasForeignKey(h => h.PatientID)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(h => h.Doctor)
                      .WithMany(d => d!.Exams)
                      .HasForeignKey(h => h.DoctorID)
                      .IsRequired()
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(h => h.Employee)
                      .WithMany(e => e!.Exams)
                      .HasForeignKey(h => h.EmployeeID)
                      .IsRequired()
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.Transaction)
                      .WithOne(p => p.Exam)
                      .HasForeignKey<PatientTransactionHistory>(p => p.ExamID)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            builder.Entity<AnalysationTest>(entity =>
            {
                entity.HasOne(a => a.HistoryMedicalExam)
                      .WithMany(p => p!.AnalysationTests)
                      .HasForeignKey(a => a.ExamID)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(a => a.DeviceService)
                      .WithMany(d => d!.AnalysationTests)
                      .HasForeignKey(a => a.DeviceID)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            builder.Entity<Suppling>(entity =>
            {
                entity.HasOne(s => s.Inventory)
                      .WithMany(i => i!.Supplings)
                      .HasForeignKey(s => s.InventoryID)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(s => s.GoodsImportation)
                      .WithMany(g => g!.Goods)
                      .HasForeignKey(s => s.ShipmentID)
                      .IsRequired()
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(s => s.Drug)
                      .WithMany(d => d!.Supplings)
                      .HasForeignKey(s => s.DrugID)
                      .IsRequired()
                      .OnDelete(DeleteBehavior.Cascade);
            });

            builder.Entity<Bill>(entity =>
            {
                entity.HasOne(b => b.Inventory)
                      .WithMany(i => i!.Bills)
                      .HasForeignKey(b => b.InventoryID)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(b => b.Transaction)
                      .WithMany(g => g!.Bills)
                      .HasForeignKey(b => b.TransactionID)
                      .IsRequired()
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(b => b.Drug)
                      .WithMany(d => d!.Bills)
                      .HasForeignKey(b => b.DrugID)
                      .IsRequired()
                      .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}
