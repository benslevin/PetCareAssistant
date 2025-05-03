
using PetCateAssistant.Services;

namespace PetCateAssistant
{
    public class AppStartupInitializer : IHostedService
    {
        private readonly IPetService _petService;
        private readonly ILogger<AppStartupInitializer> _logger;

        public AppStartupInitializer(IPetService petService, ILogger<AppStartupInitializer> logger)
        {
            _petService = petService;
            _logger = logger;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Initializing Application");
            await _petService.InitializeAsync();
            _logger.LogInformation("PetService initialization completed");
        }

        public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
    }
}
