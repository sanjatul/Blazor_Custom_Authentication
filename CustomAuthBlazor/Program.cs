using CustomAuthBlazor;
using CustomAuthBlazor.Components;
using CustomAuthBlazor.Service;
using CustomAuthBlazor.Service.Interface;
using Microsoft.AspNetCore.Identity;
using MudBlazor.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

//Authentication using cookies


builder.Services.AddAuthentication()
    .AddCookie(Constants.AuthScheme, options =>
    {
        options.Cookie.Name = Constants.AuthCookie;
        options.LoginPath = "/auth/login";
        options.AccessDeniedPath = "/auth/access-denied";
        options.LogoutPath = "/auth/logout";

        options.Cookie.HttpOnly = true;
        options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
        options.Cookie.SameSite = SameSiteMode.Strict;

        options.ExpireTimeSpan = TimeSpan.FromDays(1);
        options.SlidingExpiration = true;
    });

builder.Services.AddCascadingAuthenticationState();

//Adding Mud Blazor
builder.Services.AddMudServices();

//DbConfig
builder.Services.AddTransient<IAuthService,AuthService>();
builder.Services.AddHttpContextAccessor();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseAuthentication();
app.UseAuthorization();

app.UseAntiforgery();


app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
