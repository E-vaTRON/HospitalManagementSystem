namespace IdentitySystem.DataProvider;

public static class ServiceExtension
{
    public static void AddIdentitySystemDataProviders(this IServiceCollection services)
    {
        services.AddSingleton<UserStoreProvider>()
                .AddSingleton<RoleStoreProvider>();

        services.AddTransient<ISignInProvider, SignInProvider>();

        services.AddTransient<IUserManagerProvider, UserManagerProvider>()
                .AddTransient<IRoleManagerProvider, RoleManagerProvider>();

        services.AddIdentity<Domain.User, Domain.Role>(options =>
        {
            options.Password.RequireDigit = false;
            options.Password.RequireLowercase = false;
            options.Password.RequireUppercase = false;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequiredLength = 1;
            options.User.RequireUniqueEmail = true;
        }).AddUserManager<UserManagerProvider>()
          .AddRoleManager<RoleManagerProvider>()
          .AddUserStore<UserStoreProvider>()
          .AddRoleStore<RoleStoreProvider>()
          .AddDefaultTokenProviders();

        services.AddTransient<IDatabaseDataProvider, DatabaseDataProvider>();

        services.AddTransient<IUserDataProvider, UserDataProvider>()
                .AddTransient<IRoleDataProvider, RoleDataProvider>()
                .AddTransient<IUserClaimDataProvider, UserClaimDataProvider>()
                .AddTransient<IUserLoginDataProvider, UserLoginDataProvider>()
                .AddTransient<IUserTokenDataProvider, UserTokenDataProvider>()
                .AddTransient<IUserRoleDataProvider, UserRoleDataProvider>()
                .AddTransient<IRoleClaimDataProvider, RoleClaimDataProvider>();

        services.AddTransient<INotificationDataProvider, NotificationDataProvider>();

        services.AddTransient<IScheduleDayDataProvider, ScheduleDayDataProvider>()
                .AddTransient<IScheduleSlotDataProvider, ScheduleSlotDataProvider>();

        services.AddTransient<ISpecializationDataProvider, SpecializationDataProvider>()
                .AddTransient<IUserSpecializationDataProvider, UserSpecializationDataProvider>();
    }
}
