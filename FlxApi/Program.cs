using Flx.Data.Repository;
using Flx.Data.Repository.IRepository;
using Flx.Domain.BAC;
using Flx.Domain.BAC.IBAC;
using Flx.Domain.Identity;
using Flx.Domain.IValidators;
using Flx.Domain.Validators;
using Flx.Domain.Validators.IValidators;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.Data.SqlClient;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;

// JWT Token Security Configuration
byte[] criptographedKeyInBytes = Encoding.ASCII.GetBytes(KeyJWT.SecretKey);
builder.Services.AddAuthentication(auth =>
{
    auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(auth =>
{
    auth.RequireHttpsMetadata = false;
    auth.SaveToken = true;
    auth.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(criptographedKeyInBytes),
        ValidateIssuer = false,
        ValidateAudience = false,
    };
});

// Add services to the container.
builder.Services.AddCors(opt => opt.AddDefaultPolicy(builder => builder.WithOrigins("http://localhost:4200", "http://http://192.168.0.3:4200").AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));

// Inject IDbConnection, with implemantation from SqlConnection class
builder.Services.AddTransient<IDbConnection>(config => new SqlConnection(configuration.GetConnectionString("DefaultConnection")));

// BAC Injection
builder.Services.AddSingleton<ICategoryBac, CategoryBac>();
builder.Services.AddSingleton<IIdentityBac, IdentityBac>();

// Repository Injection
builder.Services.AddSingleton<ICategoryRepo, CategoryRepo>();
builder.Services.AddSingleton<IUserRepo, UserRepo>();

// Validator Injection
builder.Services.AddSingleton<ICategoryValidator, CategoryValidator>();
builder.Services.AddSingleton<IIdentityValidator, IdentityValidator>();

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseCors();

app.UseHttpsRedirection();

// Keeps this order: Authentication and then Authorization
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
