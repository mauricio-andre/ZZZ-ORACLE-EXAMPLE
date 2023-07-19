using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ZZZOracleExample.Core.Data;

public class OracleCoreDbContextFactory : IDbContextFactory<CoreDbContext>
{
    private readonly IServiceProvider _serviceProvider;

    /// <summary>
    /// https://github.com/dotnet/efcore/blob/main/src/EFCore/Extensions/EntityFrameworkServiceCollectionExtensions.cs
    /// https://github.com/dotnet/efcore/blob/main/src/EFCore/Internal/DbContextFactory.cs
    /// https://github.com/dotnet/efcore/blob/main/src/EFCore/Internal/DbContextFactorySource.cs
    /// </summary>
    /// <param name="serviceProvider"></param>
    /// <param name="options"></param>
    /// <param name="factorySource"></param>
    public OracleCoreDbContextFactory(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public CoreDbContext CreateDbContext() => ActivatorUtilities.CreateInstance<OracleCoreDbContext>(_serviceProvider, Type.EmptyTypes);
    public Task<CoreDbContext> CreateDbContextAsync() => Task.FromResult(CreateDbContext());
}