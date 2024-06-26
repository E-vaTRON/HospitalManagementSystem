﻿namespace IdentitySystem.DataProvider;

public class IdentitySystemDbContext : IdentityDbContext<User, Role, Guid, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>
{
    #region [ CTor ]
    public IdentitySystemDbContext(DbContextOptions<IdentitySystemDbContext> options) : base(options)
    {
        base.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        base.ChangeTracker.AutoDetectChangesEnabled = false;
    }
    #endregion

    #region [ Override ]
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
    #endregion

    #region [ Properties ]
    public virtual DbSet<Notification>          Notifications       { get; set; } = null!;
    public virtual DbSet<ScheduleDay>           ScheduleDays        { get; set; } = null!;
    public virtual DbSet<ScheduleSlot>          ScheduleSlots       { get; set; } = null!;
    public virtual DbSet<Specialization>        Specializations     { get; set; } = null!;
    public virtual DbSet<UserSpecialization>    UserSpecializations { get; set; } = null!;
    #endregion
}
