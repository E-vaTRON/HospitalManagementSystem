namespace IdentitySystem.DataProvider;

public static class ServiceExtensions
{
    #region [ Public Methods - Add ]
    public static void AddIdentitySystemSeedDataProviders(this IServiceCollection services) 
    {
        services.AddTransient<ISeedProvider, SeedServiceProvider>();
    }
    #endregion
}