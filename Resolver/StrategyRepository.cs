using MultiDI.Enums;
using MultiDI.Services.Contracts;

namespace MultiDI.Resolver;

public delegate IRepository StrategyRepository(RepositoryType type);