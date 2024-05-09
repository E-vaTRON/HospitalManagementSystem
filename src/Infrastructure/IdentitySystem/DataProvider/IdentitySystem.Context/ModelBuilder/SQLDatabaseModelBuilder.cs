﻿namespace IdentitySystem.DataProvider;

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

        modelBuilder.Entity<Specialization>()
                    .HasMany(s => s.Users)
                    .WithMany(u => u.Specializations);
    }
    #endregion
    #endregion
}
