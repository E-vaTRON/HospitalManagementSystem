using Core.Entities.UserIdentifile;
using HospitalDataBase.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HospitalDataBase.Core.Database
{
    public class ApplicationDbContext : IdentityDbContext<User, Role, string, IdentityUserClaim<string>, UserRole, IdentityUserLogin<string>, IdentityRoleClaim<string>, IdentityUserToken<string>>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public virtual DbSet<AnalysationTest> AnalysationTests { get; set; } = null!;
        public virtual DbSet<DeviceService> DeviceServices { get; set; } = null!;
        public virtual DbSet<DoctorList> Doctors { get; set; } = null!;
        public virtual DbSet<EmployeeList> Employees { get; set; } = null!;
        public virtual DbSet<Drug> Drugs { get; set; } = null!;
        public virtual DbSet<GoodsExportation> GoodsExportations { get; set; } = null!;
        public virtual DbSet<GoodsImportation> GetGoodsImportations { get; set; } = null!;
        public virtual DbSet<HistoryMedicalExam> Exams { get; set; } = null!;
        public virtual DbSet<Inventory> Inventories { get; set; } = null!;
        public virtual DbSet<Patient> Patients { get; set; } = null!;

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
                      .HasForeignKey(ur => ur.RoleId)
                      .IsRequired().OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(ur => ur.User)
                      .WithMany(u => u!.UserRoles)
                      .HasForeignKey(ur => ur.UserId)
                      .IsRequired().OnDelete(DeleteBehavior.Cascade);
            });

            builder.Entity<Inventory>(entity =>
            {
                entity.HasOne<Drug>(i => i.Drug)
                      .WithMany(d => d.Inventories)
                      .HasForeignKey(i => i.GoodID)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<GoodsExportation>(entity =>
            {
                entity.HasOne<Inventory>(g => g.Inventory)
                      .WithMany(i => i.Exportations)
                      .HasForeignKey(g => g.InventoryID)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne<HistoryMedicalExam>(g => g.HistoryMedicalExam)
                      .WithMany(h => h.GoodsExportations)
                      .HasForeignKey(g => g.ExamID)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<GoodsImportation>(entity =>
            {
                entity.HasOne<Inventory>(g => g.Inventory)
                      .WithMany(i => i.Importations)
                      .HasForeignKey(g => g.InventoryID)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<HistoryMedicalExam>(entity =>
            {
                entity.HasOne<Patient>(h => h.Patient)
                      .WithMany(p => p.Exams)
                      .HasForeignKey(h => h.PatientID)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne<DoctorList>(h => h.Doctor)
                      .WithMany(d => d.Exams)
                      .HasForeignKey(h => h.DoctorID)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne<EmployeeList>(h => h.Employee)
                      .WithMany(e => e.Exams)
                      .HasForeignKey(h => h.EmployeeID)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<AnalysationTest>(entity =>
            {
                entity.HasOne<HistoryMedicalExam>(a => a.HistoryMedicalExam)
                      .WithMany(p => p.AnalysationTests)
                      .HasForeignKey(a => a.ExamID)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne<DeviceService>(a => a.DeviceService)
                      .WithMany(d => d.AnalysationTests)
                      .HasForeignKey(a => a.DeviceID)
                      .OnDelete(DeleteBehavior.Restrict);
            });

        }
    }
}
