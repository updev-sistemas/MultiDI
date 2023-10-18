using MultiDI.Resolver;
using MultiDI.Services.Contracts;

namespace MultiDI
{
    public class SupplierWorker : BackgroundService
    {
        private readonly ILogger<SupplierWorker> _logger;
        private readonly IRepository _repository;

        public SupplierWorker(ILogger<SupplierWorker> logger,
            StrategyRepository factoryRepository)
        {
            this._logger = logger;
            this._repository = factoryRepository.Invoke(Enums.RepositoryType.Supplier);
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