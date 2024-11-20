var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddCascadingAuthenticationState();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = false,
                        ValidateLifetime = false,
                        ValidIssuer = builder.Configuration["JwtTokenConfig:Issuer"],
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtTokenConfig:Key"]!)),
                        ValidAlgorithms = new[] { SecurityAlgorithms.HmacSha256 },
                    };
                });

builder.Services.AddBlazorBootstrap();
builder.Services.AddBlazoredLocalStorage();
//builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddFluentUIComponents();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddHospitalManagementSystemApplicationServices(configuration);
builder.Services.AddIdentitySystemApplicationServices(configuration);

builder.Services.AddHospitalManagementSystemDataProviders();
builder.Services.AddIdentitySystemDataProviders();

builder.Services.AddIdentitySystemSqlServerDataProviders(configuration);
builder.Services.AddHospitalManagementSystemSqlServerDataProviders(configuration);

//builder.Services.AddIdentitySystemInMemoryDataProviders();
//builder.Services.AddHospitalManagementSystemInMemoryDataProviders();

builder.Services.AddIdentitySystemAuthenticationProvider(configuration);
builder.Services.AddIdentitySystemServicesProvider(configuration);
builder.Services.AddHospitalManagementSystemServicesProvider(configuration);

builder.Services.AddFluentUIComponents();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseMiddleware<ExceptionMiddleware>();
app.UseHttpsRedirection();

//app.UseCors("ClientPermission");
//app.UseRouting();
app.UseStaticFiles();
app.UseAntiforgery();
app.UseAuthentication();
app.UseAuthorization();

//app.MapBlazorHub();
//app.MapFallbackToPage("/Host");
app.MapRazorComponents<App>()
   .AddInteractiveServerRenderMode();

#if DEBUG
app.UseHMSInMemoryDataProviders();
app.UseISInMemoryDataProviders();
#endif

app.Run();