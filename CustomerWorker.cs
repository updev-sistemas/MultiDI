using MultiDI.Resolver;
using MultiDI.Services.Contracts;

namespace MultiDI
{
    public class CustomerWorker : BackgroundService
    {
        private readonly ILogger<CustomerWorker> _logger;
        private readonly IRepository _repository;

        public CustomerWorker(
            ILogger<CustomerWorker> logger,
            StrategyRepository factoryRepository)
        {
            this._logger = logger;
            this._repository = factoryRepository.Invoke(Enums.RepositoryType.Customer);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                this._repository!.Resolve();

                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}