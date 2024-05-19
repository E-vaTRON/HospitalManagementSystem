namespace IdentitySystem.DataProvider;

public class SQLDatabaseModelBuilder
{
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
        this.NotificationModelBuilder(modelBuilder);
        this.ScheduleDayModelBuilder(modelBuilder);
        this.ScheduleSlotModelBuilder(modelBuilder);
        this.SpecializationModelBuilder(modelBuilder);
        this.UserModelBuilder(modelBuilder);
        this.RoleModelBuilder(modelBuilder);
        this.UserRoleModelBuilder(modelBuilder);
        this.UserSpecializationModelBuilder(modelBuilder);
        this.UserClaimModelBuilder(modelBuilder);
        this.RoleClaimModelBuilder(modelBuilder);
        this.UserLoginModelBuilder(modelBuilder);
        this.UserTokenModelBuilder(modelBuilder);
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
    #region [ Identity ]
    private void UserModelBuilder(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasKey(x => x.Id);

        modelBuilder.Entity<User>()
                    .Property(r => r.Id)
                    .HasColumnType("uniqueidentifier")
                    .HasMaxLength(DataTypeHelpers.ID_FIELD_LENGTH)
                    .IsRequired(true);

        modelBuilder.Entity<User>()
                    .Property(u => u.UserName)
                    .HasColumnType("nvarchar(max)")
                    .HasMaxLength(DataTypeHelpers.NAME_FIELD_LENGTH);

        modelBuilder.Entity<User>()
                    .Property(u => u.NormalizedUserName)
                    .HasColumnType("nvarchar")
                    .HasMaxLength(DataTypeHelpers.NAME_FIELD_LENGTH);

        modelBuilder.Entity<User>()
                    .Property(u => u.Email)
                    .HasColumnType("nvarchar")
                    .HasMaxLength(DataTypeHelpers.EMAIL_FIELD_LENGTH);

        modelBuilder.Entity<User>()
                    .Property(u => u.NormalizedEmail)
                    .HasColumnType("nvarchar")
                    .HasMaxLength(DataTypeHelpers.EMAIL_FIELD_LENGTH);

        modelBuilder.Entity<User>()
                    .Property(u => u.EmailConfirmed)
                    .HasColumnType("bit");

        modelBuilder.Entity<User>()
                    .Property(u => u.PasswordHash)
                    .HasColumnType("nvarchar")
                    .HasMaxLength(DataTypeHelpers.PASSWORD_FIELD_LENGTH);

        modelBuilder.Entity<User>()
                    .Property(u => u.SecurityStamp)
                    .HasColumnType("nvarchar")
                    .HasMaxLength(DataTypeHelpers.NAME_FIELD_LENGTH);

        modelBuilder.Entity<User>()
                    .Property(u => u.ConcurrencyStamp)
                    .HasColumnType("nvarchar")
                    .HasMaxLength(DataTypeHelpers.NAME_FIELD_LENGTH);

        modelBuilder.Entity<User>()
                    .Property(u => u.PhoneNumber)
                    .HasColumnType("nvarchar")
                    .HasMaxLength(DataTypeHelpers.PHONE_NUMBER_FIELD_LENGTH);

        modelBuilder.Entity<User>()
                    .Property(u => u.PhoneNumberConfirmed)
                    .HasColumnType("bit");

        modelBuilder.Entity<User>()
                    .Property(u => u.TwoFactorEnabled)
                    .HasColumnType("bit");

        modelBuilder.Entity<User>()
                    .Property(u => u.LockoutEnd)
                    .HasColumnType("datetimeoffset");

        modelBuilder.Entity<User>()
                    .Property(u => u.LockoutEnabled)
                    .HasColumnType("bit");

        modelBuilder.Entity<User>()
                    .Property(u => u.AccessFailedCount)
                    .HasColumnType("int");

        modelBuilder.Entity<User>()
                    .Property(u => u.FirstName)
                    .HasColumnType("nvarchar")
                    .IsRequired(true);

        modelBuilder.Entity<User>()
                    .Property(u => u.LastName)
                    .HasColumnType("nvarchar")
                    .IsRequired(true);

        modelBuilder.Entity<User>()
                    .Property(u => u.Age)
                    .HasColumnType("int")
                    .IsRequired(true);

        modelBuilder.Entity<User>()
                    .Property(u => u.DayOfBirth)
                    .HasColumnType("datetime")
                    .IsRequired(true);

        modelBuilder.Entity<User>()
                    .Property(u => u.Gender)
                    .HasColumnType("bit")
                    .IsRequired(true);

        modelBuilder.Entity<User>()
                    .Property(u => u.Address)
                    .HasColumnType("nvarchar");

        modelBuilder.Entity<User>()
                    .Property(u => u.CardID)
                    .HasColumnType("nvarchar");

        modelBuilder.Entity<User>()
                    .Property(u => u.SpecialistLevel)
                    .HasColumnType("int");

        modelBuilder.Entity<User>()
                    .Property(u => u.Verified)
                    .HasColumnType("bit")
                    .IsRequired(true);

        modelBuilder.Entity<User>()
                    .Property(u => u.IsDeleted)
                    .HasColumnType("bit")
                    .IsRequired(true);

        modelBuilder.Entity<User>()
                    .Property(u => u.IsExpired)
                    .HasColumnType("bit")
                    .IsRequired(true);

        modelBuilder.Entity<User>()
                    .Property(u => u.CreatedOn)
                    .HasColumnType("datetime")
                    .IsRequired(true);

        modelBuilder.Entity<User>()
                    .Property(u => u.LastUpdatedOn)
                    .HasColumnType("datetime");

        modelBuilder.Entity<User>()
                    .Property(u => u.DeleteOn)
                    .HasColumnType("datetime");
    }
    private void RoleModelBuilder(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Role>().HasKey(x => x.Id);

        modelBuilder.Entity<Role>()
                    .Property(r => r.Id)
                    .HasColumnType("uniqueidentifier")
                    .HasMaxLength(DataTypeHelpers.ID_FIELD_LENGTH)
                    .IsRequired(true);

        modelBuilder.Entity<Role>()
                    .Property(r => r.Name)
                    .HasColumnType("nvarchar")
                    .HasMaxLength(DataTypeHelpers.NAME_FIELD_LENGTH);

        modelBuilder.Entity<Role>()
                    .Property(r => r.NormalizedName)
                    .HasColumnType("nvarchar")
                    .HasMaxLength(DataTypeHelpers.NAME_FIELD_LENGTH);

        modelBuilder.Entity<Role>()
                    .Property(r => r.ConcurrencyStamp)
                    .HasColumnType("nvarchar")
                    .HasMaxLength(DataTypeHelpers.NAME_FIELD_LENGTH);

        modelBuilder.Entity<Role>()
                    .Property(r => r.IsDeleted)
                    .HasColumnType("bit")
                    .IsRequired(true);

        modelBuilder.Entity<Role>()
                    .Property(r => r.CreatedOn)
                    .HasColumnType("datetime")
                    .IsRequired(true);

        modelBuilder.Entity<Role>()
                    .Property(r => r.LastUpdatedOn)
                    .HasColumnType("datetime");

        modelBuilder.Entity<Role>()
                    .Property(r => r.DeleteOn)
                    .HasColumnType("datetime");

    }
    private void UserRoleModelBuilder(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserRole>().HasKey(x => x.Id);

        modelBuilder.Entity<UserRole>()
                    .Property(r => r.Id)
                    .HasColumnType("uniqueidentifier")
                    .HasMaxLength(DataTypeHelpers.ID_FIELD_LENGTH)
                    .IsRequired(true);

        modelBuilder.Entity<UserRole>()
                    .Property(r => r.IsDeleted)
                    .HasColumnType("bit")
                    .IsRequired(true);

        modelBuilder.Entity<UserRole>()
                    .Property(r => r.CreatedOn)
                    .HasColumnType("datetime")
                    .IsRequired(true);

        modelBuilder.Entity<UserRole>()
                    .Property(r => r.LastUpdatedOn)
                    .HasColumnType("datetime");

        modelBuilder.Entity<UserRole>()
                    .Property(r => r.DeleteOn)
                    .HasColumnType("datetime");

        modelBuilder.Entity<UserRole>()
                    .HasOne(ur => ur.User)
                    .WithMany(u => u.UserRoles)
                    .HasForeignKey(ur => ur.UserId);

        modelBuilder.Entity<UserRole>()
                    .HasOne(ur => ur.Role)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.RoleId);
    }
    private void UserClaimModelBuilder(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserClaim>().HasKey(x => x.Id);

        modelBuilder.Entity<UserClaim>()
                    .Property(uc => uc.Id)
                    .HasColumnType("int")
                    .IsRequired(true);

        modelBuilder.Entity<UserClaim>()
                    .Property(uc => uc.ClaimType)
                    .HasMaxLength(DataTypeHelpers.NAME_FIELD_LENGTH)
                    .HasColumnType("nvarchar");

        modelBuilder.Entity<UserClaim>()
                    .Property(uc => uc.ClaimValue)
                    .HasMaxLength(DataTypeHelpers.DESCRIPTION_NAME_FIELD_LENGTH)
                    .HasColumnType("nvarchar");

        modelBuilder.Entity<UserClaim>()
                    .Property(r => r.IsDeleted)
                    .HasColumnType("bit")
                    .IsRequired(true);

        modelBuilder.Entity<UserClaim>()
                    .Property(r => r.CreatedOn)
                    .HasColumnType("datetime")
                    .IsRequired(true);

        modelBuilder.Entity<UserClaim>()
                    .Property(r => r.LastUpdatedOn)
                    .HasColumnType("datetime");

        modelBuilder.Entity<UserClaim>()
                    .Property(r => r.DeleteOn)
                    .HasColumnType("datetime");

        modelBuilder.Entity<UserClaim>()
                    .HasOne(n => n.User)
                    .WithMany(u => u.UserClaims)
                    .HasForeignKey(n => n.UserId);
    }
    private void UserLoginModelBuilder(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserLogin>().HasKey(x => x.Id);

        modelBuilder.Entity<UserLogin>()
                    .Property(r => r.Id)
                    .HasColumnType("uniqueidentifier")
                    .HasMaxLength(DataTypeHelpers.ID_FIELD_LENGTH)
                    .IsRequired(true);

        modelBuilder.Entity<UserLogin>()
                    .Property(ul => ul.LoginProvider)
                    .HasColumnType("nvarchar")
                    .HasMaxLength(DataTypeHelpers.NAME_FIELD_LENGTH)
                    .IsRequired(true);

        modelBuilder.Entity<UserLogin>()
                    .Property(ul => ul.ProviderKey)
                    .HasColumnType("nvarchar")
                    .HasMaxLength(DataTypeHelpers.NAME_FIELD_LENGTH)
                    .IsRequired(true);

        modelBuilder.Entity<UserLogin>()
                    .Property(ul => ul.ProviderDisplayName)
                    .HasMaxLength(DataTypeHelpers.NAME_FIELD_LENGTH)
                    .HasColumnType("nvarchar");

        modelBuilder.Entity<UserLogin>()
                    .Property(r => r.IsDeleted)
                    .HasColumnType("bit")
                    .IsRequired(true);

        modelBuilder.Entity<UserLogin>()
                    .Property(r => r.CreatedOn)
                    .HasColumnType("datetime")
                    .IsRequired(true);

        modelBuilder.Entity<UserLogin>()
                    .Property(r => r.LastUpdatedOn)
                    .HasColumnType("datetime");

        modelBuilder.Entity<UserLogin>()
                    .Property(r => r.DeleteOn)
                    .HasColumnType("datetime");

        modelBuilder.Entity<UserLogin>()
                    .HasOne(n => n.User)
                    .WithMany(u => u.UserLogins)
                    .HasForeignKey(n => n.UserId);
    }
    private void RoleClaimModelBuilder(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<RoleClaim>().HasKey(x => x.Id);

        modelBuilder.Entity<RoleClaim>()
                    .Property(rc => rc.Id)
                    .HasColumnType("int")
                    .IsRequired(true);

        modelBuilder.Entity<RoleClaim>()
                    .Property(rc => rc.ClaimType)
                    .HasColumnType("nvarchar")
                    .HasMaxLength(DataTypeHelpers.DESCRIPTION_NAME_FIELD_LENGTH);

        modelBuilder.Entity<RoleClaim>()
                    .Property(rc => rc.ClaimValue)
                    .HasColumnType("nvarchar")
                    .HasMaxLength(DataTypeHelpers.DESCRIPTION_NAME_FIELD_LENGTH);

        modelBuilder.Entity<RoleClaim>()
                    .Property(r => r.IsDeleted)
                    .HasColumnType("bit")
                    .IsRequired(true);

        modelBuilder.Entity<RoleClaim>()
                    .Property(r => r.CreatedOn)
                    .HasColumnType("datetime")
                    .IsRequired(true);

        modelBuilder.Entity<RoleClaim>()
                    .Property(r => r.LastUpdatedOn)
                    .HasColumnType("datetime");

        modelBuilder.Entity<RoleClaim>()
                    .Property(r => r.DeleteOn)
                    .HasColumnType("datetime");

        modelBuilder.Entity<RoleClaim>()
                    .HasOne(n => n.Role)
                    .WithMany(u => u.RoleClaims)
                    .HasForeignKey(n => n.RoleId);
    }
    private void UserTokenModelBuilder(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserToken>().HasKey(x => x.Id);

        modelBuilder.Entity<UserLogin>()
                    .Property(r => r.Id)
                    .HasColumnType("uniqueidentifier")
                    .HasMaxLength(DataTypeHelpers.ID_FIELD_LENGTH)
                    .IsRequired(true);

        modelBuilder.Entity<UserToken>()
                    .Property(ut => ut.LoginProvider)
                    .HasColumnType("nvarchar(max)")
                    .HasMaxLength(DataTypeHelpers.NAME_FIELD_LENGTH)
                    .IsRequired(true);

        modelBuilder.Entity<UserToken>()
                    .Property(ut => ut.Name)
                    .HasColumnType("nvarchar")
                    .HasMaxLength(DataTypeHelpers.NAME_FIELD_LENGTH)
                    .IsRequired(true);

        modelBuilder.Entity<UserToken>()
                    .Property(ut => ut.Value)
                    .HasColumnType("nvarchar(max)");

        modelBuilder.Entity<UserToken>()
                    .Property(r => r.IsDeleted)
                    .HasColumnType("bit")
                    .IsRequired(true);

        modelBuilder.Entity<UserToken>()
                    .Property(r => r.CreatedOn)
                    .HasColumnType("datetime")
                    .IsRequired(true);

        modelBuilder.Entity<UserToken>()
                    .Property(r => r.LastUpdatedOn)
                    .HasColumnType("datetime");

        modelBuilder.Entity<UserToken>()
                    .Property(r => r.DeleteOn)
                    .HasColumnType("datetime");

        modelBuilder.Entity<UserToken>()
                    .HasOne(n => n.User)
                    .WithMany(u => u.UserTokens)
                    .HasForeignKey(n => n.UserId);
    }
    #endregion

    #region [ Notification - Schedule ]
    private void NotificationModelBuilder(ModelBuilder modelBuilder)
    {
        this.BaseModelBuilder<Notification>(modelBuilder, nameof(Notification));

        modelBuilder.Entity<Notification>()
                    .Property(n => n.Status)
                    .HasColumnType("nvarchar");

        modelBuilder.Entity<Notification>()
                    .Property(n => n.Message)
                    .HasColumnType("nvarchar");

        modelBuilder.Entity<Notification>()
                    .Property(n => n.RedirectUrl)
                    .HasColumnType("nvarchar");

        modelBuilder.Entity<Notification>()
                    .Property(n => n.UserId)
                    .HasColumnType("nvarchar");

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
                    .HasColumnType("int")
                    .IsRequired(true);

        modelBuilder.Entity<ScheduleDay>()
                    .Property(sd => sd.IsFlexible)
                    .HasColumnType("bit")
                    .IsRequired(true);

        modelBuilder.Entity<ScheduleDay>()
                    .Property(sd => sd.UserId)
                    .HasColumnType("nvarchar");

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
                    .HasColumnType("int")
                    .IsRequired(true);

        modelBuilder.Entity<ScheduleSlot>()
                    .Property(ss => ss.EndTime)
                    .HasColumnType("int")
                    .IsRequired(true);

        modelBuilder.Entity<ScheduleSlot>()
                    .Property(ss => ss.Task)
                    .HasColumnType("nvarchar");

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
                    .HasColumnType("nvarchar")
                    .IsRequired(true);

        modelBuilder.Entity<Specialization>()
                    .Property(s => s.Description)
                    .HasColumnType("nvarchar");
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
