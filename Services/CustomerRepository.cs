using MultiDI.Services.Contracts;

namespace MultiDI.Services;

public sealed class CustomerRepository : IRepository
{
    private readonly ILogger<CustomerRepository> _logger;

    public CustomerRepository(ILogger<CustomerRepository> logger)
    {
        this._logger = logger;
    }

    public void Resolve()
    {
        this._logger.LogInformation(nameof(CustomerRepository));
    }
}
