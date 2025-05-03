using Microsoft.Extensions.DependencyInjection;
using PetCateAssistant;
using PetCateAssistant.Logging;
using PetCateAssistant.Models;
using PetCateAssistant.Services;
using Serilog;

//Logger initialization
LoggerConfigurator.ConfigureLogger();

var builder = WebApplication.CreateBuilder(args);

//Add Configuration
builder.Services.Configure<PetDataOptions>(builder.Configuration.GetSection("PetData"));
builder.Host.UseSerilog();

// Add services to the container.
builder.Services.AddSingleton<IFileService, FileService>();
builder.Services.AddSingleton<IPetService, PetService>();

//central Startup Logic
builder.Services.AddHostedService<AppStartupInitializer>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseSerilogRequestLogging();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
