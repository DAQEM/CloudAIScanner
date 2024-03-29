using AIRegister;
using BusinessLogic.Interfaces;
using Microsoft.EntityFrameworkCore;
using DAL;
using DAL.Repositories;
using System.Web.Http;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
        corsPolicyBuilder => corsPolicyBuilder.WithOrigins("http://localhost:5050")
            .AllowAnyMethod()
            .AllowAnyHeader());
});

builder.Services.AddControllers(options =>
{
    options.Filters.Add<HttpExceptionHandlingAttribute>();
});

builder.Services.AddScoped<IAISystemRepository, AISystemRepository>();
builder.Services.AddScoped<IProviderRepository, ProviderRepository>();
builder.Services.AddScoped<IRepresentativeRepository, RepresentativeRepository>();
builder.Services.AddScoped<IFileRepository, FileRepository>();

IConfigurationRoot config;
if (builder.Environment.IsDevelopment())
{
    config = new ConfigurationBuilder()
        .AddJsonFile("appsettings.Development.json")
        .Build();
}
else
{
    config = new ConfigurationBuilder()
        .AddJsonFile("appsettings.json")
        .Build();
}


string? connectionString = config.GetConnectionString("MySqlConnection");

builder.Services.AddDbContext<AIRegisterDBContext>(options =>
{
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString),
        optionsBuilder => optionsBuilder.MigrationsAssembly("AIRegister"));
}, ServiceLifetime.Transient);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


WebApplication app = builder.Build();

app.UseCors("CorsPolicy");

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();