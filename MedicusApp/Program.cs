using AspNet.Security.OAuth.Keycloak;
using MedicusApp.Config;
using MedicusApp.Models;
using MedicusApp.Models.Seeding;
using MedicusApp.Repositories;
using MedicusApp.Repositories.Impl;
using MedicusApp.Services;
using MedicusApp.Services.Impl;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication()
    .AddKeycloak(options =>
    {
        var config = builder.Configuration.GetSection("Keycloak").Get<KeycloakConfiguration>();
        options.ClientId = config.ClientId;
        options.ClientSecret = config.ClientSecret;
        options.Realm = config.Realm;
        options.BaseAddress = new Uri(config.BaseAddress);
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DatabaseContext>();

builder.Services.AddTransient<ISpecRepository, SpecRepository>();
builder.Services.AddTransient<ILinkRepository, LinkRepository>();
builder.Services.AddTransient<ICompanyRepository, CompanyRepository>();

builder.Services.AddTransient<ISpecService, SpecService>();
builder.Services.AddTransient<ILinkService, LinkService>();
builder.Services.AddTransient<ICompanyService, CompanyService>();

builder.Services.AddSingleton<Seeder>();

builder.Services.AddControllers().AddJsonOptions(options =>
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseHsts();
} else
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseHttpsRedirection();
}

app.UseAuthentication();
app.UseAuthorization();
app.UseStaticFiles();
app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");

app.Run();