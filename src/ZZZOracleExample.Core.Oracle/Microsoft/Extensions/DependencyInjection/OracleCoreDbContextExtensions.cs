using ZZZOracleExample.Core.Data;
using Microsoft.EntityFrameworkCore;

namespace Microsoft.Extensions.DependencyInjection;

public static class OracleCoreDbContextExtensions
{
    public static IServiceCollection AddOracleCoreDbContext(this IServiceCollection services, Action<EntityFrameworkCore.DbContextOptionsBuilder> optionsAction)
        => services
            .AddScoped<CoreDbContext, OracleCoreDbContext>()
            .AddDbContextFactory<CoreDbContext, OracleCoreDbContextFactory>(optionsAction);
}