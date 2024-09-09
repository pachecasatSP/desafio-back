using desafio_back.api.IoC.EventStore;
using desafio_back.api.IoC.Repositories;
using desafio_back.api.IoC.Rules;
using desafio_back.api.IoC.Services;
using desafio_back.api.MinimalApis;
using desafio_back.api.Models.Validators;
using desafio_back.infrastructure.Events;
using desafio_back.infrastructure.Repositories.Context;
using desafio_back.web.api.Profiles;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

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

builder.Services.AddControllers();

builder.Services.RegisterRules();
builder.Services.RegisterServices();
builder.Services.RegisterRepositories();
builder.Services.AddScoped<EventStore>();

builder.Services.AddValidatorsFromAssemblyContaining<CreateMotorcycleCommandValidator>();

builder.Host.UseSerilog();

builder.Services.AddMediatR(opt =>
{
    opt.RegisterServicesFromAssembly(typeof(Program).Assembly);
});

builder.Services.RegisterMasstransit(builder.Configuration);

var serviceProvider = builder.Services.BuildServiceProvider();
var rentalManagementDB = serviceProvider.GetRequiredService<RentalManagementContext>();
var auditDB = serviceProvider.GetRequiredService<AuditContext>();

await rentalManagementDB.Database.MigrateAsync();
await auditDB.Database.MigrateAsync();

//builder.Services.Configure<JsonOptions>(opts => opts.SerializerOptions.WriteIndented = true);

var app = builder.Build();

app.UseHttpsRedirection();
app.MapMotorcycleEndpoints();

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
