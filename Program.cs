using MultiDI;
using MultiDI.Enums;
using MultiDI.Resolver;
using MultiDI.Services;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((host, services) =>
    {
        services.AddOptions();

        services.AddSingleton<CustomerRepository>();
        services.AddSingleton<SupplierRepository>();

        services.AddSingleton<StrategyRepository>(provider => (type) =>
        {
            return type switch
            {
                RepositoryType.Customer => provider.GetRequiredService<CustomerRepository>(),
                RepositoryType.Supplier => provider.GetRequiredService<SupplierRepository>(),
                _ => throw new NotImplementedException("Repository not found."),
            };
        });

        services.AddHostedService<SupplierWorker>();
        services.AddHostedService<CustomerWorker>();
    })
    .Build();

await host.RunAsync();
