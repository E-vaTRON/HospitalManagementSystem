namespace IdentitySystem.ServiceProvider;

public static class ServiceExtension
{
    #region [ Public Methods - Add ]
    public static void AddHospitalManagementSystemServicesProvider(this IServiceCollection services)
    {
        //services.Configure<JwtTokenConfig>(configuration.GetSection(nameof(JwtTokenConfig)));
        //services.Configure<IdentityAzureStorageConfig>(configuration.GetSection(nameof(IdentityAzureStorageConfig)));

        //services.AddIdentity<User, Role>(options =>
        //{
        //    options.Password.RequireDigit = false;
        //    options.Password.RequireLowercase = false;
        //    options.Password.RequireUppercase = false;
        //    options.Password.RequireNonAlphanumeric = false;
        //    options.Password.RequiredLength = 1;
        //    options.User.RequireUniqueEmail = true;
        //})
        //    .AddUserManager<UserManager>()
        //    .AddEntityFrameworkStores<PetaverseIdentityContext>();

        //services.AddTransient<Func<IdentityContainerEnum, BlobContainerClient>>(provider => container =>
        //{
        //    var config = provider.GetRequiredService<IOptionsMonitor<IdentityAzureStorageConfig>>().CurrentValue;
        //    switch (container)
        //    {
        //        case IdentityContainerEnum.AvatarContainer:
        //            return new BlobContainerClient(config.BlobConnectionString, config.AvatarStorage);

        //        case IdentityContainerEnum.PhotoContainer:
        //            return new BlobContainerClient(config.BlobConnectionString, config.PhotoStorage);

        //        default:
        //            return new BlobContainerClient(config.BlobConnectionString, config.PhotoStorage);
        //    }
        //});

        //services.AddSingleton((provider) =>
        //{
        //    var config = provider.GetRequiredService<IOptionsMonitor<IdentityAzureStorageConfig>>().CurrentValue;
        //    return new StorageSharedKeyCredential(config.AccountName, config.AccountKey);
        //});

        //services.AddTransient<IJwtTokenService, JWTTokenService>();
        //services.AddTransient<IIdentityMediaService, IdentityMediaService>();
        //services.AddTransient<IAuthenticationService, AuthenticationService>();

        //services.AddScoped<IPetaverseUserRepository, UserRepository>();

        //services.AddTransient<IBookingAppointmentServiceProvider,   BookingAppointmentServiceProvider>()
        //        .AddTransient<IReExamAppointmentServiceProvider,    ReExamAppointmentServiceProvider>()
        //        .AddTransient<IReferralServiceProvider,             ReferralServiceProvider>()
        //        .AddTransient<IReferralDoctorServiceProvider,       ReferralDoctorServiceProvider>();
    }



    public static void AddHospitalManagementSystemServicesProvider(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddHospitalManagementSystemServicesProvider();
    }
    #endregion
}
