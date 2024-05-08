namespace HospitalManagementSystem.Application;

public interface ISeedProvider
{
    #region [ Methods - Database ]
    Task EnsureDatabaseAsync(Action action = null!);

    Task DropDatabaseAsync(Action action = null!);
    #endregion

    #region [ Methods - Seed ]
    Task SeedDatabaseAsync();

    Task ClearDatabaseAsync();
    #endregion
}
