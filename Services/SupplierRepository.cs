using MultiDI.Services.Contracts;

namespace MultiDI.Services;

public sealed class SupplierRepository : IRepository
{
    private readonly ILogger<SupplierRepository> _logger;

    public SupplierRepository(ILogger<SupplierRepository> logger)
    {
        this._logger = logger;
    }

    public void Resolve()
    {
        this._logger.LogInformation(nameof(SupplierRepository));
    }
}
