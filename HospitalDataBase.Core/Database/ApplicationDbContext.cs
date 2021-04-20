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

        public virtual DbSet<Analysation> Analysations { get; set; } = null!;
        public virtual DbSet<DeviceService> DeviceServices { get; set; } = null!;
        public virtual DbSet<DoctorList> Doctors { get; set; } = null!;
        public virtual DbSet<EmployeeList> Employees { get; set; } = null!;
        public virtual DbSet<Drug> Drugs { get; set; } = null!;
        public virtual DbSet<GoodsExportation> GoodsExportations { get; set; } = null!;
        public virtual DbSet<GoodsImportation> GetGoodsImportations { get; set; } = null!;
        public virtual DbSet<HistoryMedicalExam> Exams { get; set; } = null!;
        public virtual DbSet<Inventory> Inventories { get; set; } = null!;
        public virtual DbSet<Patient> Patients { get; set; } = null!;
        public virtual DbSet<Test> Tests { get; set; } = null;

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
                entity.HasOne<Drug>(e => e.Drug)
                      .WithMany(d => d.Exportations)
                      .HasForeignKey(e => e.GoodID)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<GoodsImportation>(entity =>
            {
                entity.HasOne<Drug>(i => i.Drug)
                      .WithMany(d => d.Importations)
                      .HasForeignKey(i => i.GoodID)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<HistoryMedicalExam>(entity =>
            {
                entity.HasOne<Patient>(h => h.Patient)
                      .WithMany(p => p.Exams)
                      .HasForeignKey(h => h.PatientID)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<Analysation>(entity =>
            {
                entity.HasOne<Patient>(a => a.Patient)
                      .WithMany(p => p.Analysations)
                      .HasForeignKey(a => a.PatientID)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<Test>(entity =>
            {
                entity.HasOne<Patient>(t => t.Patient)
                      .WithMany(p => p.Tests)
                      .HasForeignKey(t => t.PatientID)
                      .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
