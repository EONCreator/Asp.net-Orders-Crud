using AsuManagement.OrdersCrud.Domain.Interfaces;
using AsuManagement.OrdersCrud.Domain.Services;
using AsuManagement.OrdersCrud.Services.Commands.Orders.CreateOrder;
using MediatR;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using AsuManagement.OrdersCrud.Presenters;
using AsuManagement.OrdersCrud.Interaction;
using AsuManagement.OrdersCrud.Domain.Interfaces.Results;
using AsuManagement.OrdersCrud.Domain.Core.Entities;
using AutoMapper;
using AsuManagement.OrdersCrud.Presenters.Orders;
using AsuManagement.OrdersCrud.Domain.Services.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var services = builder.Services;

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

services
    .AddScoped<IInteractionBus, InteractionBus>()
    .AddDbContext<AppDbContext>(options =>
    {
        options.UseNpgsql(connectionString);
        options.EnableSensitiveDataLogging();
    })
    .AddScoped<IEntityRepository>(f => f.GetRequiredService<AppDbContext>())
    .AddMediatR(AppDomain.CurrentDomain.GetAssemblies())
    .AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies())
    
    .AddResponsesPresenters()
    .AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");

using var scope = app.Services.CreateScope();

var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
db.Database.Migrate();

await scope.ServiceProvider.GetRequiredService<DatabaseInitializer>().Initialize();

app.Run();
