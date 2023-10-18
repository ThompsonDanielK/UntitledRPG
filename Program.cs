using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using UntitledRPG.Database;
using UntitledRPG.Engine.Interfaces;
using UntitledRPG.Engine.Utilities;
using UntitledRPG.Models.IdentityModels;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddUserSecrets(Assembly.GetExecutingAssembly(), true);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add DbContext with IConfiguration instance
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DATABASE_CONNECTION_STRING"), new MariaDbServerVersion(new Version(8, 0, 34))));
builder.Services.AddDbContext<IdentityContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DATABASE_CONNECTION_STRING"), new MariaDbServerVersion(new Version(8, 0, 34))));

// Identity services
builder.Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<IdentityContext>()
    .AddDefaultTokenProviders();

// Dependency injection
builder.Services.AddScoped<IDice, Dice>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
