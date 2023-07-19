using ZZZOracleExample.Core.Examples;
using Microsoft.EntityFrameworkCore;

namespace ZZZOracleExample.Core.Data;

public class OracleCoreDbContext : CoreDbContext
{
    public OracleCoreDbContext(DbContextOptions<CoreDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new ExampleEfConfiguration());
    }
}