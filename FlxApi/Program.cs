using Flx.Data.Repository;
using Flx.Data.Repository.IRepository;
using Flx.Domain.BAC;
using Flx.Domain.BAC.IBAC;
using Flx.Domain.IValidators;
using Flx.Domain.Validators;
using System.Data;
using System.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;

// Add services to the container.
builder.Services.AddCors(opt => opt.AddDefaultPolicy(builder => builder.WithOrigins("http://localhost:4200", "http://http://192.168.0.3:4200").AllowAnyOrigin().AllowAnyMethod()));

// Inject IDbConnection, with implemantation from SqlConnection class
builder.Services.AddTransient<IDbConnection>(config => new SqlConnection(configuration.GetConnectionString("DefaultConnection")));

// Repository Injection
builder.Services.AddSingleton<ICategoryRepo, CategoryRepo>();

// BAC Injection
builder.Services.AddSingleton<ICategoryBac, CategoryBac>();

// Validator Injection
builder.Services.AddSingleton<ICategoryValidator, CategoryValidator>();


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
