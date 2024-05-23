namespace IdentitySystem.ServiceProvider;

public static class ServiceExtension
{
    #region [ Public Methods - Add ]
    public static void AddIdentitySystemServicesProvider(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddTransient<IDatabaseServiceProvider, DatabaseServiceProvider>();

        services.AddTransient<INotificationServiceProvider, NotificationServiceProvider>();

        services.AddTransient<IScheduleDayServiceProvider, ScheduleDayServiceProvider>()
                .AddTransient<IScheduleDayServiceProvider, ScheduleDayServiceProvider>();

        services.AddTransient<ISpecializationServiceProvider, SpecializationServiceProvider>();

        services.AddTransient<IUserServiceProvider, UserServiceProvider>()
                .AddTransient<IRoleServiceProvider, RoleServiceProvider>()
                .AddTransient<IUserRoleServiceProvider, UserRoleServiceProvider>();
    }
    #endregion
}
