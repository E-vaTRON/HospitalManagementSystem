var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

builder.Services.AddControllers();
builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddSwaggerGen(options => options.SwaggerDoc("v1", new OpenApiInfo { Title = "HospitalDataBaseApi", Version = "v1" }));

builder.Services.AddCors(options =>
{
    options.AddPolicy("ClientPermission", policy =>
    {
        policy.AllowAnyHeader()
              .AllowAnyMethod()
              .WithOrigins("http://localhost:7094")
              .AllowCredentials();
    });
});

builder.Services.AddLocalization();

//var mapperConfig = new MapperConfiguration(mc => mc.AddProfile(new MappingProfile()));
//IMapper mapper = mapperConfig.CreateMapper();
//builder.Services.AddSingleton(mapper);

builder.Services.AddHospitalManagementSystemApplicationServices(configuration);
builder.Services.AddIdentitySystemApplicationServices(configuration);

builder.Services.AddIdentitySystemSqlServerDataProviders(configuration);
builder.Services.AddHospitalManagementSystemSqlServerDataProviders(configuration);

builder.Services.AddIdentitySystemInMemoryDataProviders();
builder.Services.AddHospitalManagementSystemInMemoryDataProviders();

builder.Services.AddIdentitySystemAuthenticationProvider(configuration);
builder.Services.AddIdentitySystemServicesProvider(configuration);
builder.Services.AddHospitalManagementSystemServicesProvider(configuration);

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseDeveloperExceptionPage();
    app.UseHsts();
}

app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "HospitalDataBase v1"));

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseCors("ClientPermission");
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

#if DEBUG
app.UseHMSInMemoryDataProviders();
app.UseISInMemoryDataProviders();
#endif

app.MapControllers();
app.Run();