using Flx.Data.Repository;
using Flx.Core.BAC;
using Flx.Core.Identity;
using Flx.Core.Interfaces.IBAC;
using Flx.Core.Interfaces.IRepository;
using Flx.Core.IValidators;
using Flx.Core.Validators;
using Flx.Core.Validators.IValidators;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.Data.SqlClient;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;

// JWT Token Security Configuration
var jwtSection = configuration.GetSection("JWTSettings");
builder.Services.Configure<KeyJWT>(jwtSection);
KeyJWT appSettings = jwtSection.Get<KeyJWT>();

byte[] criptographedKeyInBytes = Encoding.ASCII.GetBytes(appSettings.SecretKey);
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
builder.Services.AddCors(opt => opt.AddDefaultPolicy(builder => builder.WithOrigins("http://localhost:4200", "http://192.168.0.204:3000").AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));

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

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.UseHttpsRedirection();

// Keeps this order: Authentication and then Authorization
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
