using Serilog;

namespace PetCateAssistant.Logging
{
    public static class LoggerConfigurator
    {
        public static void ConfigureLogger()
        {
            Log.Logger = new LoggerConfiguration()
                        .WriteTo.Console()
                        .WriteTo.File("Logs.log.txt", rollingInterval: RollingInterval.Day)
                        .Enrich.FromLogContext()    
                        .MinimumLevel.Debug()
                        .CreateLogger();
        }
    }
}
