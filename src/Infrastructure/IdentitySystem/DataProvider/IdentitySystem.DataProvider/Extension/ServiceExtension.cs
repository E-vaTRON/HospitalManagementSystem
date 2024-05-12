namespace IdentitySystem.DataProvider;

public static class ServiceExtension
{
    public static void AddIdentitySystemDataProviders(this IServiceCollection services)
    {

        services.AddSingleton<UserStoreProvider>()
                .AddSingleton<RoleStoreProvider>()
                .AddSingleton<UserRoleStoreProvider>();

        services.AddTransient<INotificationDataProvider, NotificationDataProvider>();

        services.AddTransient<IScheduleDayDataProvider, ScheduleDayDataProvider>()
                .AddTransient<IScheduleDayDataProvider, ScheduleDayDataProvider>();

        services.AddTransient<ISpecializationDataProvider, SpecializationDataProvider>();

        services.AddTransient<IUserDataProvider, UserDataProvider>()
                .AddTransient<IRoleDataProvider, RoleDataProvider>()
                .AddTransient<IUserRoleDataProvider, UserRoleDataProvider>();
    }
}
