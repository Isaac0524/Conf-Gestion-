using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Conferences_projet.Data;
using Conferences_projet.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;
using Conferences_projet.Components;
using Conferences_projet.Components.Account;
using Conferences_projet.Components.Pages;
using Microsoft.AspNetCore.Routing;
using Conferences_projet.service;
using Microsoft.AspNetCore.Components.Authorization;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

builder.Services.AddRazorComponents().AddInteractiveServerComponents();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(configuration.GetConnectionString("DefaultConnection"), new MySqlServerVersion(new Version(8, 0, 29))));

builder.Services.AddIdentityCore<Utilisateur>(options =>
{
    options.SignIn.RequireConfirmedAccount = true;
})
  .AddRoles<IdentityRole<int>>()
  .AddEntityFrameworkStores<ApplicationDbContext>()
  .AddDefaultTokenProviders()
  .AddSignInManager();


builder.Services.AddSingleton<IEmailSender<Utilisateur>, IdentityNoOpEmailSender>();
builder.Services.AddScoped<IArticleService, ArticleService>();
builder.Services.AddScoped<IConferenceService, ConferenceService>();

builder.Services.AddCascadingAuthenticationState();
builder.Services.AddScoped<IdentityUserAccessor>();
builder.Services.AddScoped<IdentityRedirectManager>();
builder.Services.AddScoped<AuthenticationStateProvider, IdentityRevalidatingAuthenticationStateProvider>();

builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = IdentityConstants.ApplicationScheme;
    options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
})
    .AddIdentityCookies();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole<int>>>();

    // Créer les rôles
    string[] Role = { "Administrateur", "Auteur", "MembreComite", "Participant", "Relecteur" };
    foreach (var role in Role)
    {
        var roleExist = await roleManager.RoleExistsAsync(role);
        if (!roleExist)
        {
            // Créer le rôle s'il n'existe pas
            await roleManager.CreateAsync(new IdentityRole<int>(role));
        }
    }
}

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>().AddInteractiveServerRenderMode();
app.MapAdditionalIdentityEndpoints();

app.Run();
