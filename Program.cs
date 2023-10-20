using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using UntitledRPG.Data;
using UntitledRPG.Database;
using UntitledRPG.Engine.Utilities;
using UntitledRPG.Models.IdentityModels;
using UntitledRPG.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddUserSecrets(Assembly.GetExecutingAssembly(), true);

// Add services to the container.
builder.Services.AddControllers();

// Identity services
builder.Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<IdentityContext>()
    .AddDefaultTokenProviders();

// Add authorization services
builder.Services.ConfigureApplicationCookie(options =>
{
    // Cookie settings
    options.Cookie.HttpOnly = true;
    options.ExpireTimeSpan = TimeSpan.FromMinutes(30);

    options.LoginPath = "/api/Identity/login";
    options.AccessDeniedPath = "/api/404";
    options.SlidingExpiration = true;
});

builder.Services.AddAuthorization(options =>
{
    options.FallbackPolicy = new AuthorizationPolicyBuilder()
        .RequireAuthenticatedUser()
        .Build();
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add DbContext with IConfiguration instance
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DATABASE_CONNECTION_STRING"), new MariaDbServerVersion(new Version(8, 0, 34))));
builder.Services.AddDbContext<IdentityContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DATABASE_CONNECTION_STRING"), new MariaDbServerVersion(new Version(8, 0, 34))));

// Dependency injection
builder.Services.AddScoped<IPlayerCharacterService, PlayerCharacterService>();
builder.Services.AddScoped<IPlayerCharacterRepository, PlayerCharacterRepository>();
builder.Services.AddScoped<IRollService, RollService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
