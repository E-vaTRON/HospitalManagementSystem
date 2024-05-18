namespace IdentitySystem.DataProvider;

public class SQLiteDatabaseModelBuilder
{
    #region [ Singleton ]
    private static readonly Lazy<SQLiteDatabaseModelBuilder> sqliteModel = new Lazy<SQLiteDatabaseModelBuilder>(
        () => new SQLiteDatabaseModelBuilder(), LazyThreadSafetyMode.PublicationOnly);
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
    #region [ Identity ]
    private void UserModelBuilder(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
                   .Property(r => r.Id)
                   .HasColumnType("TEXT")
                   .HasMaxLength(DataTypeHelpers.ID_FIELD_LENGTH)
                   .IsRequired(true);

        modelBuilder.Entity<User>()
                    .Property(u => u.UserName)
                    .HasColumnType("TEXT")
                    .HasMaxLength(DataTypeHelpers.NAME_FIELD_LENGTH);

        modelBuilder.Entity<User>()
                    .Property(u => u.NormalizedUserName)
                    .HasColumnType("TEXT")
                    .HasMaxLength(DataTypeHelpers.NAME_FIELD_LENGTH);

        modelBuilder.Entity<User>()
                    .Property(u => u.Email)
                    .HasColumnType("TEXT")
                    .HasMaxLength(DataTypeHelpers.EMAIL_FIELD_LENGTH);

        modelBuilder.Entity<User>()
                    .Property(u => u.NormalizedEmail)
                    .HasColumnType("TEXT")
                    .HasMaxLength(DataTypeHelpers.EMAIL_FIELD_LENGTH);

        modelBuilder.Entity<User>()
                    .Property(u => u.EmailConfirmed)
                    .HasColumnType("INTEGER");

        modelBuilder.Entity<User>()
                    .Property(u => u.PasswordHash)
                    .HasColumnType("TEXT")
                    .HasMaxLength(DataTypeHelpers.PASSWORD_FIELD_LENGTH);

        modelBuilder.Entity<User>()
                    .Property(u => u.SecurityStamp)
                    .HasColumnType("TEXT")
                    .HasMaxLength(DataTypeHelpers.NAME_FIELD_LENGTH);

        modelBuilder.Entity<User>()
                    .Property(u => u.ConcurrencyStamp)
                    .HasColumnType("TEXT")
                    .HasMaxLength(DataTypeHelpers.NAME_FIELD_LENGTH);

        modelBuilder.Entity<User>()
                    .Property(u => u.PhoneNumber)
                    .HasColumnType("TEXT")
                    .HasMaxLength(DataTypeHelpers.PHONE_NUMBER_FIELD_LENGTH);

        modelBuilder.Entity<User>()
                    .Property(u => u.PhoneNumberConfirmed)
                    .HasColumnType("INTEGER");

        modelBuilder.Entity<User>()
                    .Property(u => u.TwoFactorEnabled)
                    .HasColumnType("INTEGER");

        modelBuilder.Entity<User>()
                    .Property(u => u.LockoutEnd)
                    .HasColumnType("TEXT");

        modelBuilder.Entity<User>()
                    .Property(u => u.LockoutEnabled)
                    .HasColumnType("INTEGER");

        modelBuilder.Entity<User>()
                    .Property(u => u.AccessFailedCount)
                    .HasColumnType("INTEGER");

        modelBuilder.Entity<User>()
                    .Property(u => u.FirstName)
                    .HasColumnType("TEXT")
                    .IsRequired(true);

        modelBuilder.Entity<User>()
                    .Property(u => u.LastName)
                    .HasColumnType("TEXT")
                    .IsRequired(true);

        modelBuilder.Entity<User>()
                    .Property(u => u.Age)
                    .HasColumnType("INTEGER")
                    .IsRequired(true);

        modelBuilder.Entity<User>()
                    .Property(u => u.DayOfBirth)
                    .HasColumnType("TEXT")
                    .IsRequired(true);

        modelBuilder.Entity<User>()
                    .Property(u => u.Gender)
                    .HasColumnType("INTEGER")
                    .IsRequired(true);

        modelBuilder.Entity<User>()
                    .Property(u => u.Address)
                    .HasColumnType("TEXT");

        modelBuilder.Entity<User>()
                    .Property(u => u.CardID)
                    .HasColumnType("TEXT");

        modelBuilder.Entity<User>()
                    .Property(u => u.SpecialistLevel)
                    .HasColumnType("INTEGER");

        modelBuilder.Entity<User>()
                    .Property(u => u.Verified)
                    .HasColumnType("INTEGER")
                    .IsRequired(true);

        modelBuilder.Entity<User>()
                    .Property(u => u.IsDeleted)
                    .HasColumnType("INTEGER")
                    .IsRequired(true);

        modelBuilder.Entity<User>()
                    .Property(u => u.IsExpired)
                    .HasColumnType("INTEGER")
                    .IsRequired(true);

        modelBuilder.Entity<User>()
                    .Property(u => u.CreatedOn)
                    .HasColumnType("TEXT")
                    .IsRequired(true);

        modelBuilder.Entity<User>()
                    .Property(u => u.LastUpdatedOn)
                    .HasColumnType("TEXT");

        modelBuilder.Entity<User>()
                    .Property(u => u.DeleteOn)
                    .HasColumnType("TEXT");
    }

    private void RoleModelBuilder(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Role>()
                    .Property(r => r.Id)
                    .HasColumnType("TEXT")
                    .HasMaxLength(DataTypeHelpers.ID_FIELD_LENGTH)
                    .IsRequired(true);

        modelBuilder.Entity<Role>()
                    .Property(r => r.Name)
                    .HasColumnType("TEXT")
                    .HasMaxLength(DataTypeHelpers.NAME_FIELD_LENGTH);

        modelBuilder.Entity<Role>()
                    .Property(r => r.NormalizedName)
                    .HasColumnType("TEXT")
                    .HasMaxLength(DataTypeHelpers.NAME_FIELD_LENGTH);

        modelBuilder.Entity<Role>()
                    .Property(r => r.ConcurrencyStamp)
                    .HasColumnType("TEXT")
                    .HasMaxLength(DataTypeHelpers.NAME_FIELD_LENGTH);

        modelBuilder.Entity<Role>()
                    .Property(r => r.IsDeleted)
                    .HasColumnType("INTEGER")
                    .IsRequired(true);

        modelBuilder.Entity<Role>()
                    .Property(r => r.CreatedOn)
                    .HasColumnType("TEXT")
                    .IsRequired(true);

        modelBuilder.Entity<Role>()
                    .Property(r => r.LastUpdatedOn)
                    .HasColumnType("TEXT");

        modelBuilder.Entity<Role>()
                    .Property(r => r.DeleteOn)
                    .HasColumnType("TEXT");
    }

    private void UserRoleModelBuilder(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserRole>()
                    .HasOne(ur => ur.User)
                    .WithMany(u => u.UserRoles)
                    .HasForeignKey(ur => ur.UserId);

        modelBuilder.Entity<UserRole>()
                    .HasOne(ur => ur.Role)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.RoleId);
    }
    #endregion

    #region [ Notification - Schedule ]
    private void NotificationModelBuilder(ModelBuilder modelBuilder)
    {
        this.BaseModelBuilder<Notification>(modelBuilder, nameof(Notification));

        modelBuilder.Entity<Notification>()
                    .Property(n => n.Status);

        modelBuilder.Entity<Notification>()
                    .Property(n => n.Message);

        modelBuilder.Entity<Notification>()
                    .Property(n => n.RedirectUrl);

        modelBuilder.Entity<Notification>()
                    .Property(n => n.UserId);

        modelBuilder.Entity<Notification>()
                    .HasOne(n => n.User)
                    .WithMany(u => u.Notifications)
                    .HasForeignKey(n => n.UserId);

    }

    private void ScheduleDayModelBuilder(ModelBuilder modelBuilder)
    {
        this.BaseModelBuilder<ScheduleDay>(modelBuilder, nameof(ScheduleDay));

        modelBuilder.Entity<ScheduleDay>()
                    .Property(sd => sd.WorkingDay)
                    .IsRequired(true);

        modelBuilder.Entity<ScheduleDay>()
                    .Property(sd => sd.IsFlexible)
                    .IsRequired(true);

        modelBuilder.Entity<ScheduleDay>()
                    .Property(sd => sd.UserId);

        modelBuilder.Entity<ScheduleDay>()
                    .HasOne(sd => sd.User)
                    .WithMany(u => u.ScheduleDays)
                    .HasForeignKey(sd => sd.UserId);
    }
    private void ScheduleSlotModelBuilder(ModelBuilder modelBuilder)
    {
        this.BaseModelBuilder<ScheduleSlot>(modelBuilder, nameof(ScheduleSlot));

        modelBuilder.Entity<ScheduleSlot>()
                .Property(ss => ss.StartTime)
                .IsRequired(true);

        modelBuilder.Entity<ScheduleSlot>()
                .Property(ss => ss.EndTime)
                .IsRequired(true);

        modelBuilder.Entity<ScheduleSlot>()
                .Property(ss => ss.Task);

        modelBuilder.Entity<ScheduleSlot>()
                .HasOne(ss => ss.ScheduleDay)
                .WithMany(sd => sd.ScheduleSlots)
                .HasForeignKey(ss => ss.ScheduleDayId);
    }

    private void SpecializationModelBuilder(ModelBuilder modelBuilder)
    {
        this.BaseModelBuilder<Specialization>(modelBuilder, nameof(Specialization));

        modelBuilder.Entity<Specialization>()
                .Property(s => s.Name)
                .IsRequired(true);

        modelBuilder.Entity<Specialization>()
                .Property(s => s.Description);
    }

    private void UserSpecializationModelBuilder(ModelBuilder modelBuilder)
    {
        this.BaseModelBuilder<UserSpecialization>(modelBuilder, nameof(Specialization));

        modelBuilder.Entity<UserSpecialization>()
                    .HasOne(us => us.User)
                    .WithMany(u => u.UserSpecializations)
                    .HasForeignKey(us => us.UserId);

        modelBuilder.Entity<UserSpecialization>()
                    .HasOne(us => us.Specialization)
                    .WithMany(s => s.UserSpecializations)
                    .HasForeignKey(us => us.SpecializationId);
    }

    #endregion
    #endregion
}
