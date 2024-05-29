var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddFluentUIComponents();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();
app.UseAuthentication();
app.UseAuthorization();

app.UseRouting();

app.MapBlazorHub();
//app.MapFallbackToPage("/Host");
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
