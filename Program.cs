using BlazorApp20.Services;
using MudBlazor.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// ✅ BOTH must be Singleton so state is shared across all pages
builder.Services.AddSingleton<SupabaseService>();
builder.Services.AddSingleton<AuthService>();
builder.Services.AddScoped<WeatherService>();
builder.Services.AddMudServices();
builder.Services.AddHttpClient();

var app = builder.Build();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<BlazorApp20.Components.App>()
    .AddInteractiveServerRenderMode();

app.Run();
