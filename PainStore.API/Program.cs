using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using Serilog;
using FluentValidation;
using PaintStore.Models.DTOs;
using PaintStore.DataAccess;
using PaintStore.Models.Interfaces.Services;
using PaintStore.Services.Services;
using PaintStore.Models.Interfaces.Repositories;
using PaintStore.Repositories;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddJsonOptions(x=>x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddDbContext<PaintStoreDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        b => b.MigrationsAssembly("PaintStore.DataAccess")));

// TODO: remove
builder.Services.AddScoped<PaintStoreDbContext>();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();


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