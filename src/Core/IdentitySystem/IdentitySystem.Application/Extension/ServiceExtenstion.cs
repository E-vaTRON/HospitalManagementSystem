namespace IdentitySystem.Application;

public static class ServiceExtenstion
{
    public static void AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        //services.AddAzureBlobStorage(configuration);
        services.AddLogging();
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        //services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

        //services.AddValidatorsFromAssemblyContaining<CreateAnimalCommandValidator>();
    }
}
