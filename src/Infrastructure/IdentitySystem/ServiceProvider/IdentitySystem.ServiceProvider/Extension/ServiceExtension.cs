namespace IdentitySystem.ServiceProvider;

public static class ServiceExtension
{
    #region [ Public Methods - Add ]
    public static void AddIdentitySystemServicesProvider(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        services.AddTransient<ISServiceContext>();

        services.AddTransient<IDatabaseServiceProvider, DatabaseServiceProvider>();

        services.AddTransient<INotificationServiceProvider, NotificationServiceProvider>();

        services.AddTransient<IScheduleDayServiceProvider, ScheduleDayServiceProvider>()
                .AddTransient<IScheduleSlotServiceProvider, ScheduleSlotServiceProvider>();

        services.AddTransient<ISpecializationServiceProvider, SpecializationServiceProvider>()
                .AddTransient<IUserSpecializationServiceProvider, UserSpecializationServiceProvider>();

        services.AddTransient<IUserServiceProvider, UserServiceProvider>()
                .AddTransient<IRoleServiceProvider, RoleServiceProvider>()
                .AddTransient<IUserClaimServiceProvider, UserClaimServiceProvider>()
                .AddTransient<IUserLoginServiceProvider, UserLoginServiceProvider>()
                .AddTransient<IUserTokenServiceProvider, UserTokenServiceProvider>()
                .AddTransient<IUserRoleServiceProvider, UserRoleServiceProvider>()
                .AddTransient<IRoleClaimServiceProvider, RoleClaimServiceProvider>();
    }
    #endregion
}
