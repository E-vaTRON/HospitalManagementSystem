namespace HospitalManagementSystem.ServiceProvider;

public static class ServiceExtension
{
    public static IServiceCollection AddServicesProvider(this IServiceCollection services,
                                                            IConfiguration configuration)
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

        //services.AddScoped<IAnalyzationTestRepository, AnalyzationTestRepository>()
        //        .AddScoped<IDeviceServiceRepository, DeviceServiceRepository>()
        //        .AddScoped<IDoctorRepository, DoctorRepository>()
        //        .AddScoped<IDrugRepository, DrugRepository>()
        //        .AddScoped<IEmployeeRepository, EmployeeRepository>()
        //        .AddScoped<IGoodsImportationRepository, GoodsImportationRepository>()
        //        .AddScoped<IHistoryMedicalExamRepository, HistoryMedicalExamRepository>()
        //        .AddScoped<IInventoryRepository, InventoryRepository>()
        //        .AddScoped<IPatientRepository, PatientRepository>()
        //        .AddScoped<IStorageRepository, StorageRepository>()
        //        .AddScoped<IUserRepository, UserRepository>()
        //        .AddScoped<ISupplingRepository, SupplingRepository>()
        //        .AddScoped<IBillRepository, BillRepository>();

        return services;
    }

}
