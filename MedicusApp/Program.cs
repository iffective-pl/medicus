using MedicusApp.Config;
using MedicusApp.Models;
using MedicusApp.Models.Seeding;
using MedicusApp.Repositories;
using MedicusApp.Repositories.Impl;
using MedicusApp.Services;
using MedicusApp.Services.Impl;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        var config = builder.Configuration.GetSection("Keycloak").Get<KeycloakConfiguration>();
        options.MetadataAddress = config.MetadataAddress;
        options.Authority = config.Authority;
        options.Audience = config.Audience;
        options.RequireHttpsMetadata = config.RequireHttpsMetadata;
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DatabaseContext>();

builder.Services.AddTransient<ISpecRepository, SpecRepository>();
builder.Services.AddTransient<IUIRepository, UIRepository>();
builder.Services.AddTransient<ICompanyRepository, CompanyRepository>();
builder.Services.AddTransient<IDoctorRepository, DoctorRepository>();

builder.Services.AddTransient<ISpecService, SpecService>();
builder.Services.AddTransient<IUIService, UIService>();
builder.Services.AddTransient<ICompanyService, CompanyService>();
builder.Services.AddTransient<IDoctorService, DoctorService>();

builder.Services.AddSingleton<Seeder>();
builder.Services.AddSingleton<MinioService>();

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

app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");

app.Run();