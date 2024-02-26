namespace HospitalManagementSystem.DataProvider;

public class ContextFactory : IDesignTimeDbContextFactory<HospitalManagementSystemDbContext>
{
    public HospitalManagementSystemDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<HospitalManagementSystemDbContext>();
        optionsBuilder.UseSqlServer(string.Empty);
        return new HospitalManagementSystemDbContext(optionsBuilder.Options);
    }
}
