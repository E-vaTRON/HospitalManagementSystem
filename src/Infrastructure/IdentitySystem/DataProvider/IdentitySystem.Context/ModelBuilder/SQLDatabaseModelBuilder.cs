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
    #region [  ]
    private void UserModelBuilder(ModelBuilder modelBuilder)
    {
    }
    private void RoleModelBuilder(ModelBuilder modelBuilder)
    {
    }
    private void UserRoleModelBuilder(ModelBuilder modelBuilder)
    {
    }
    #endregion

    #region [  ]
    private void NotificationModelBuilder(ModelBuilder modelBuilder)
    {
        this.BaseModelBuilder<Notification>(modelBuilder, nameof(Notification));
    }

    private void ScheduleDayModelBuilder(ModelBuilder modelBuilder)
    {
        this.BaseModelBuilder<ScheduleDay>(modelBuilder, nameof(ScheduleDay));
    }

    private void ScheduleSlotModelBuilder(ModelBuilder modelBuilder)
    {
        this.BaseModelBuilder<ScheduleSlot>(modelBuilder, nameof(ScheduleSlot));
    }

    private void SpecializationModelBuilder(ModelBuilder modelBuilder)
    {
        this.BaseModelBuilder<Specialization>(modelBuilder, nameof(Specialization));
    }
    #endregion
    #endregion
}
