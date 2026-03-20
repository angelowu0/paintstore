using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using Serilog;
using FluentValidation;
using PaintStore.Models.DTOs;
using PaintStore.DataAccess;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddJsonOptions(x=>x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddDbContext<PaintStoreDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));

// TODO: remove
builder.Services.AddScoped<PaintStoreDbContext>();

// Abstraction <-------------> Implementation

// If app version, can choose v1 or v2

builder.Services.AddAutoMapper(typeof(ServiceExtensions));

builder.Services.AddValidatorsFromAssemblyContaining<CreateUserRequest>();

// IPaymentService

Log.Logger = new LoggerConfiguration()
.WriteTo.Console()
.WriteTo.File("logs/log.txt", rollingInterval: RollingInterval.Day)
.CreateLogger();

builder.Host.UseSerilog();

var app = builder.Build();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();