using MedicusApp.Models;
using MedicusApp.Models.Seeding;
using MedicusApp.Repositories;
using MedicusApp.Repositories.Impl;
using MedicusApp.Services;
using MedicusApp.Services.Impl;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DatabaseContext>();

builder.Services.AddTransient<ISpecRepository, SpecRepository>();
builder.Services.AddTransient<ILinkRepository, LinkRepository>();

builder.Services.AddTransient<ISpecService, SpecService>();
builder.Services.AddTransient<ILinkService, LinkService>();

builder.Services.AddSingleton<Seeds>();

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");

app.Run();