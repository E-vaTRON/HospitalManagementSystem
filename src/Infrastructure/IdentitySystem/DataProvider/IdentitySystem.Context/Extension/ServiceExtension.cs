namespace IdentitySystem.DataProvider;

public static class ServiceExtension
{
    #region [ Public Methods - Add ]
    public static void AddIdentitySystemDataBaseContextProviders(this IServiceCollection services)
    {
        services.AddTransient<IdentitySystemDbContext>(); // Add this   
    }
    #endregion
}
