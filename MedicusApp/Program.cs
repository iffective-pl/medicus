using MedicusApp.Config;
using MedicusApp.Models;
using MedicusApp.Models.Seeding;
using MedicusApp.Repositories;
using MedicusApp.Repositories.Impl;
using MedicusApp.Services;
using MedicusApp.Services.Impl;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Net;
using System.Net.Mail;
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
var config = builder.Configuration.GetSection("Mail").Get<EmailConfiguration>();
builder.Services.AddFluentEmail(config.Username, "No Reply")
    .AddSmtpSender(new SmtpClient()
    {
         Host = config.Server,
         Port = config.Port,
         EnableSsl = true,
         Credentials = new NetworkCredential(config.Username, config.Password)
    })
    .AddLiquidRenderer();

builder.Services.AddDbContext<DatabaseContext>();

builder.Services.AddTransient<ISpecRepository, SpecRepository>();
builder.Services.AddTransient<IUIRepository, UIRepository>();
builder.Services.AddTransient<ICompanyRepository, CompanyRepository>();
builder.Services.AddTransient<IDoctorRepository, DoctorRepository>();
builder.Services.AddTransient<IDescRepository, DescRepository>();
builder.Services.AddTransient<IStaticRepository, StaticRepository>();
builder.Services.AddTransient<IMPRepository, MPRepository>();

builder.Services.AddTransient<ISpecService, SpecService>();
builder.Services.AddTransient<IUIService, UIService>();
builder.Services.AddTransient<ICompanyService, CompanyService>();
builder.Services.AddTransient<IDoctorService, DoctorService>();
builder.Services.AddTransient<IDescService, DescService>();
builder.Services.AddTransient<IStaticService, StaticService>();
builder.Services.AddTransient<IMPService, MPService>();

builder.Services.AddTransient<IEmailService, EmailService>();

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