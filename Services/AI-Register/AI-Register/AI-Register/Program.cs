using BusinessLogic.Interfaces;
using Microsoft.EntityFrameworkCore;
using DAL;
using DAL.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddScoped<IAISystemRepository, AISystemRepository>();
//add DBcontext
IConfigurationRoot config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();

builder.Services.AddDbContext<AIRegisterDBContext>(
    options =>
    {
        options.UseMySql(config.GetConnectionString("MySqlConnection"),
            ServerVersion.AutoDetect(config.GetConnectionString("MySqlConnection")));
    }, ServiceLifetime.Transient);

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


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
