using desafio_back.api.Apis;
using desafio_back.api.IoC.Infrastructure;
using desafio_back.api.IoC.Messaging;
using desafio_back.api.IoC.Repositories;
using desafio_back.api.IoC.Rules;
using desafio_back.api.IoC.Services;
using desafio_back.api.Middlewares;
using desafio_back.api.Models.Validators;
using desafio_back.infrastructure.Events;
using desafio_back.infrastructure.Repositories.Context;
using desafio_back.web.api.Profiles;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

var configuration = new ConfigurationBuilder()
    .AddJsonFile($"appsettings.json", true, true)
    .AddEnvironmentVariables().Build();

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .CreateLogger();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(config =>
{
    config.AddProfile<RentalManagementProfile>();
});

builder.Services.AddDbContext<AuditContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("AuditDB"));
    options.UseSnakeCaseNamingConvention();
}, ServiceLifetime.Scoped);

builder.Services.AddDbContext<RentalManagementContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultDB"));
    options.UseSnakeCaseNamingConvention();
}, ServiceLifetime.Scoped);

builder.Services.RegisterSatelliteServices(configuration);
builder.Services.RegisterRules();
builder.Services.RegisterServices();
builder.Services.RegisterRepositories();
builder.Services.AddScoped<EventStore>();

builder.Services.AddValidatorsFromAssemblyContaining<CreateMotorcycleRequestValidator>();

builder.Host.UseSerilog();

builder.Services.AddMediatR(opt =>
{
    opt.RegisterServicesFromAssembly(typeof(Program).Assembly);
});

builder.Services.RegisterMasstransit(builder.Configuration);

builder.AddFluentValidationEndpointFilter();

var serviceProvider = builder.Services.BuildServiceProvider();
var rentalManagementDB = serviceProvider.GetRequiredService<RentalManagementContext>();
var auditDB = serviceProvider.GetRequiredService<AuditContext>();

await rentalManagementDB.Database.MigrateAsync();
await auditDB.Database.MigrateAsync();

var app = builder.Build();

app.UseHttpsRedirection();

app.MapMotorcycleEndpoints();
app.MapDeliveryManEndpoints();
app.MapRentalEndpoints();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}

app.UseMiddleware<LoggingMiddleware>();
app.UseMiddleware<ErrorHandlingMiddleware>();


app.Run();

public partial class Program { }
