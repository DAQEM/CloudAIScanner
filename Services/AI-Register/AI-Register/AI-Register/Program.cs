using BusinessLogic.Interfaces;
using Microsoft.EntityFrameworkCore;
using DAL;
using DAL.Repositories;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddScoped<IAISystemRepository, AISystemRepository>();
builder.Services.AddScoped<IProviderRepository, ProviderRepository>();

IConfigurationRoot config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();

string? connectionString = config.GetConnectionString("MySqlConnection");

builder.Services.AddDbContext<AIRegisterDBContext>(options =>
{
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString),
        optionsBuilder => optionsBuilder.MigrationsAssembly("AIRegister"));
}, ServiceLifetime.Transient);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IAISystemRepository, AISystemRepository>();

WebApplication app = builder.Build();

app.UseCors(corsPolicyBuilder =>
    corsPolicyBuilder
        .WithOrigins("http://localhost:5050/")
        .AllowAnyMethod()
        .AllowAnyHeader());

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();