using PetCateAssistant.Logging;
using PetCateAssistant.Services;
using Serilog;

LoggerConfigurator.ConfigureLogger();

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseSerilog();

// Add services to the container.
builder.Services.AddSingleton<IFileService, FileService>();
builder.Services.AddSingleton<IPetService, PetService>();
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
